using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TREC.Entity;
using TRECommon;

namespace TREC.Data
{
    public class MarketStoreyShops
    {
        #region 获取卖场楼层店铺信息

        /// <summary>
        /// 获取卖场楼层店铺信息
        /// </summary>
        /// <param name="strWhere">where条件  where ''</param>
        /// <returns></returns>
        public static EnWebMarketStoreyShop GetWebMarketStoreyShopInfo(string strWhere)
        {

            EnWebMarketStoreyShop model = new EnWebMarketStoreyShop();
            IDataReader reader = DataCommon.GetDataIReader(TableName.TVMarketStoreyShop, "", strWhere, "");
            while (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["marketid"] != null && reader["marketid"].ToString() != "")
                {
                    model.marketid = int.Parse(reader["marketid"].ToString());
                }
                if (reader["markettitle"] != null && reader["markettitle"].ToString() != "")
                {
                    model.markettitle = reader["markettitle"].ToString();
                }
                if (reader["storeyid"] != null && reader["storeyid"].ToString() != "")
                {
                    model.storeyid = int.Parse(reader["storeyid"].ToString());
                }
                if (reader["storeytitle"] != null && reader["storeytitle"].ToString() != "")
                {
                    model.storeytitle = reader["storeytitle"].ToString();
                }
                if (reader["shopid"] != null && reader["shopid"].ToString() != "")
                {
                    model.shopid = int.Parse(reader["shopid"].ToString());
                }
                if (reader["shoptitle"] != null && reader["shoptitle"].ToString() != "")
                {
                    model.shoptitle = reader["shoptitle"].ToString();
                }
                if (reader["brandidlist"] != null && reader["brandidlist"].ToString() != "")
                {
                    model.brandidlist = reader["brandidlist"].ToString();
                }
                if (reader["brandtitlelist"] != null && reader["brandtitlelist"].ToString() != "")
                {
                    model.brandtitlelist = reader["brandtitlelist"].ToString();
                }
                if (reader["istop"] != null && reader["istop"].ToString() != "")
                {
                    model.istop = int.Parse(reader["istop"].ToString());
                }
                if (reader["isrecommend"] != null && reader["isrecommend"].ToString() != "")
                {
                    model.isrecommend = int.Parse(reader["isrecommend"].ToString());
                }
                if (reader["lev"] != null && reader["lev"].ToString() != "")
                {
                    model.lev = int.Parse(reader["lev"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["shopthumb"] != null && reader["shopthumb"].ToString() != "")
                {
                    model.shopthumb = reader["shopthumb"].ToString();
                }
                if (reader["shopmap"] != null && reader["shopmap"].ToString() != "")
                {
                    model.shopmap = reader["shopmap"].ToString();
                }
                if (reader["shoplinkman"] != null && reader["shoplinkman"].ToString() != "")
                {
                    model.shoplinkman = reader["shoplinkman"].ToString();
                }
                if (reader["shopphone"] != null && reader["shopphone"].ToString() != "")
                {
                    model.shopphone = reader["shopphone"].ToString();
                }
                if (reader["shopareacode"] != null && reader["shopareacode"].ToString() != "")
                {
                    model.shopareacode = reader["shopareacode"].ToString();
                }
                if (reader["shopaddress"] != null && reader["shopaddress"].ToString() != "")
                {
                    model.shopaddress = reader["shopaddress"].ToString();
                }
                if (reader["brandxml"] != null && reader["brandxml"].ToString() != "")
                {
                    model.brandxml = reader["brandxml"].ToString();
                }
            }
            reader.Close();
            if (!reader.IsClosed)
            {
                reader.Close();
            }
            return model;
        }
        #endregion

        #region 获取卖场楼层店铺列表分页信息

       /// <summary>
        /// 获取卖场楼层店铺列表分页信息
       /// </summary>
       /// <param name="PageIndex"></param>
       /// <param name="PageSize"></param>
       /// <param name="strWhere"></param>
       /// <param name="sortkey"></param>
       /// <param name="ordertype"></param>
       /// <param name="pageCount"></param>
       /// <returns></returns>
        public static List<EnWebMarketStoreyShop> GetWebWebMarketStoreyShopList(int PageIndex, int PageSize, string strWhere,string sortkey, string ordertype, out int pageCount)
        {
            List<EnWebMarketStoreyShop> list = new List<EnWebMarketStoreyShop>();
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TVMarketStoreyShop, PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);
            while (reader.Read())
            {
                EnWebMarketStoreyShop model = new EnWebMarketStoreyShop();
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["marketid"] != null && reader["marketid"].ToString() != "")
                {
                    model.marketid = int.Parse(reader["marketid"].ToString());
                }
                if (reader["markettitle"] != null && reader["markettitle"].ToString() != "")
                {
                    model.markettitle = reader["markettitle"].ToString();
                }
                if (reader["storeyid"] != null && reader["storeyid"].ToString() != "")
                {
                    model.storeyid = int.Parse(reader["storeyid"].ToString());
                }
                if (reader["storeytitle"] != null && reader["storeytitle"].ToString() != "")
                {
                    model.storeytitle = reader["storeytitle"].ToString();
                }
                if (reader["shopid"] != null && reader["shopid"].ToString() != "")
                {
                    model.shopid = int.Parse(reader["shopid"].ToString());
                }
                if (reader["shoptitle"] != null && reader["shoptitle"].ToString() != "")
                {
                    model.shoptitle = reader["shoptitle"].ToString();
                }
                if (reader["brandidlist"] != null && reader["brandidlist"].ToString() != "")
                {
                    model.brandidlist = reader["brandidlist"].ToString();
                }
                if (reader["brandtitlelist"] != null && reader["brandtitlelist"].ToString() != "")
                {
                    model.brandtitlelist = reader["brandtitlelist"].ToString();
                }
                if (reader["istop"] != null && reader["istop"].ToString() != "")
                {
                    model.istop = int.Parse(reader["istop"].ToString());
                }
                if (reader["isrecommend"] != null && reader["isrecommend"].ToString() != "")
                {
                    model.isrecommend = int.Parse(reader["isrecommend"].ToString());
                }
                if (reader["lev"] != null && reader["lev"].ToString() != "")
                {
                    model.lev = int.Parse(reader["lev"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["shopthumb"] != null && reader["shopthumb"].ToString() != "")
                {
                    model.shopthumb = reader["shopthumb"].ToString();
                }
                if (reader["shopmap"] != null && reader["shopmap"].ToString() != "")
                {
                    model.shopmap = reader["shopmap"].ToString();
                }
                if (reader["shoplinkman"] != null && reader["shoplinkman"].ToString() != "")
                {
                    model.shoplinkman = reader["shoplinkman"].ToString();
                }
                if (reader["shopphone"] != null && reader["shopphone"].ToString() != "")
                {
                    model.shopphone = reader["shopphone"].ToString();
                }
                if (reader["shopareacode"] != null && reader["shopareacode"].ToString() != "")
                {
                    model.shopareacode = reader["shopareacode"].ToString();
                }
                if (reader["shopaddress"] != null && reader["shopaddress"].ToString() != "")
                {
                    model.shopaddress = reader["shopaddress"].ToString();
                }
                if (reader["brandxml"] != null && reader["brandxml"].ToString() != "")
                {
                    model.brandxml = reader["brandxml"].ToString();
                }
                if (reader["qq"] != null && reader["qq"].ToString() != "")
                {
                    model.qq = reader["qq"].ToString();
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


        #region 批量更新卖场楼层店铺
        
        public static int UpMarketShorey(List<EnMarketStoreyShop> list)
        {
            List<CommandInfo> cmdList = new List<CommandInfo>();

            //更新前删除
            CommandInfo delShopBrand = new CommandInfo();


            foreach (EnMarketStoreyShop sb in list)
            {
                if (sb.marketid != 0 && sb.shopid!=0)
                {
                    CommandInfo model = new CommandInfo();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from t_marketstoreyshop where marketid=");
                    strSql.Append(sb.marketid);
                    strSql.Append(" and shopid=");
                    strSql.Append(sb.shopid);
                    strSql.Append("insert into t_marketstoreyshop(");
                    strSql.Append("marketid,markettitle,storeyid,storeytitle,shopid,shoptitle,brandidlist,brandtitlelist,istop,isrecommend,lev,sort,lastedid,lastedittime,position,linestatus,source,createtime,PavilionId)");
                    strSql.Append(" values (");
                    strSql.Append("@marketid,@markettitle,@storeyid,@storeytitle,@shopid,@shoptitle,@brandidlist,@brandtitlelist,@istop,@isrecommend,@lev,@sort,@lastedid,@lastedittime,@position,@linestatus,@source,@createtime,@PavilionId)");
                    strSql.Append(";select @@IDENTITY");
                    SqlParameter[] parameters = {
					new SqlParameter("@marketid", SqlDbType.Int,4),
					new SqlParameter("@markettitle", SqlDbType.NVarChar,50),
					new SqlParameter("@storeyid", SqlDbType.Int,4),
					new SqlParameter("@storeytitle", SqlDbType.NVarChar,50),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@shoptitle", SqlDbType.NVarChar,50),
					new SqlParameter("@brandidlist", SqlDbType.VarChar,50),
					new SqlParameter("@brandtitlelist", SqlDbType.NVarChar,200),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@isrecommend", SqlDbType.Int,4),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
                    new SqlParameter("@position",SqlDbType.VarChar,50),
                                                 new SqlParameter("@linestatus", SqlDbType.Int,4),
                    new SqlParameter("@source", SqlDbType.Int,4),
                    new SqlParameter("@createtime", SqlDbType.DateTime),
                    new SqlParameter("@PavilionId", SqlDbType.Int)
                    
                                                };
                    parameters[0].Value = sb.marketid;
                    parameters[1].Value = sb.markettitle;
                    parameters[2].Value = sb.storeyid;
                    parameters[3].Value = sb.storeytitle;
                    parameters[4].Value = sb.shopid;
                    parameters[5].Value = sb.shoptitle;
                    parameters[6].Value = sb.brandidlist;
                    parameters[7].Value = sb.brandtitlelist;
                    parameters[8].Value = sb.istop;
                    parameters[9].Value = sb.isrecommend;
                    parameters[10].Value = sb.lev;
                    parameters[11].Value = sb.sort;
                    parameters[12].Value = sb.lastedid;
                    parameters[13].Value = sb.lastedittime;
                    parameters[14].Value = sb.position;
                    parameters[15].Value = sb.linestatus;
                    parameters[16].Value = sb.source;
                    parameters[17].Value = sb.createtime;
                    parameters[18].Value = sb.PavilionId;
                    model.CommandText = strSql.ToString();
                    model.Parameters = parameters;
                    model.EffentNextType = EffentNextType.ExcuteEffectRows;
                    cmdList.Add(model);
                }

            }

            return DbHelper.ExecuteSqlTran(cmdList);
        }
        #endregion

        #region 更新卖场楼层店铺

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMarketStoreyShop(EnMarketStoreyShop model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_marketstoreyshop(");
                strSql.Append("marketid,markettitle,storeyid,storeytitle,shopid,shoptitle,brandidlist,brandtitlelist,istop,isrecommend,lev,sort,lastedid,lastedittime,position,linestatus,source,createtime,PavilionId)");
                strSql.Append(" values (");
                strSql.Append("@marketid,@markettitle,@storeyid,@storeytitle,@shopid,@shoptitle,@brandidlist,@brandtitlelist,@istop,@isrecommend,@lev,@sort,@lastedid,@lastedittime,@position,@linestatus,@source,@createtime,@PavilionId)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@marketid", SqlDbType.Int,4),
					new SqlParameter("@markettitle", SqlDbType.NVarChar,50),
					new SqlParameter("@storeyid", SqlDbType.Int,4),
					new SqlParameter("@storeytitle", SqlDbType.NVarChar,50),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@shoptitle", SqlDbType.NVarChar,50),
					new SqlParameter("@brandidlist", SqlDbType.VarChar,50),
					new SqlParameter("@brandtitlelist", SqlDbType.NVarChar,200),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@isrecommend", SqlDbType.Int,4),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
                    new SqlParameter("@position", SqlDbType.VarChar,50),
                    new SqlParameter("@linestatus", SqlDbType.Int,4),
                    new SqlParameter("@source", SqlDbType.Int,4),
                    new SqlParameter("@createtime", SqlDbType.DateTime),
                     new SqlParameter("@PavilionId", SqlDbType.Int)
                                            };
                parameters[0].Value = model.marketid;
                parameters[1].Value = model.markettitle;
                parameters[2].Value = model.storeyid;
                parameters[3].Value = model.storeytitle;
                parameters[4].Value = model.shopid;
                parameters[5].Value = model.shoptitle;
                parameters[6].Value = model.brandidlist;
                parameters[7].Value = model.brandtitlelist;
                parameters[8].Value = model.istop;
                parameters[9].Value = model.isrecommend;
                parameters[10].Value = model.lev;
                parameters[11].Value = model.sort;
                parameters[12].Value = model.lastedid;
                parameters[13].Value = model.lastedittime;
                parameters[14].Value = model.position;
                parameters[15].Value = model.linestatus;
                parameters[16].Value = model.source;
                parameters[17].Value = model.createtime;
                parameters[18].Value = model.PavilionId;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_marketstoreyshop set ");
                strSql.Append("marketid=@marketid,");
                strSql.Append("markettitle=@markettitle,");
                strSql.Append("storeyid=@storeyid,");
                strSql.Append("storeytitle=@storeytitle,");
                strSql.Append("shopid=@shopid,");
                strSql.Append("shoptitle=@shoptitle,");
                strSql.Append("brandidlist=@brandidlist,");
                strSql.Append("brandtitlelist=@brandtitlelist,");
                strSql.Append("istop=@istop,");
                strSql.Append("isrecommend=@isrecommend,");
                strSql.Append("lev=@lev,");
                strSql.Append("sort=@sort,");
                strSql.Append("lastedid=@lastedid,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("position=@position, ");
                strSql.Append("linestatus=@linestatus, ");
                strSql.Append("PavilionId=@PavilionId, ");
                strSql.Append("source=@source ");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@marketid", SqlDbType.Int,4),
					new SqlParameter("@markettitle", SqlDbType.NVarChar,50),
					new SqlParameter("@storeyid", SqlDbType.Int,4),
					new SqlParameter("@storeytitle", SqlDbType.NVarChar,50),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@shoptitle", SqlDbType.NVarChar,50),
					new SqlParameter("@brandidlist", SqlDbType.VarChar,50),
					new SqlParameter("@brandtitlelist", SqlDbType.NVarChar,200),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@isrecommend", SqlDbType.Int,4),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
                    new SqlParameter("@position", SqlDbType.VarChar,50),
                    new SqlParameter("@linestatus", SqlDbType.Int,4),
                    new SqlParameter("@source", SqlDbType.Int),
					new SqlParameter("@id", SqlDbType.Int),
                    new SqlParameter("@PavilionId", SqlDbType.Int)
                                            };
                parameters[0].Value = model.marketid;
                parameters[1].Value = model.markettitle;
                parameters[2].Value = model.storeyid;
                parameters[3].Value = model.storeytitle;
                parameters[4].Value = model.shopid;
                parameters[5].Value = model.shoptitle;
                parameters[6].Value = model.brandidlist;
                parameters[7].Value = model.brandtitlelist;
                parameters[8].Value = model.istop;
                parameters[9].Value = model.isrecommend;
                parameters[10].Value = model.lev;
                parameters[11].Value = model.sort;
                parameters[12].Value = model.lastedid;
                parameters[13].Value = model.lastedittime;
                parameters[14].Value = model.position;
                parameters[15].Value = model.linestatus;
                parameters[16].Value = model.source;
                parameters[17].Value = model.id;
                parameters[18].Value = model.PavilionId;
                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.id;
                }
            }

            return 0;

        }
        #endregion

        #region 获取楼层店铺详细信息
        
     /// <summary>
        /// 获取楼层店铺详细信息
     /// </summary>
     /// <param name="strWhere"> where 条件 where id=1 and uid='</param>
     /// <returns></returns>
        public static EnMarketStoreyShop GetMarketStoreyShopInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_MarketStoreyShop ");
            strSql.Append(strWhere);


            EnMarketStoreyShop model = new EnMarketStoreyShop();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["marketid"] != null && reader["marketid"].ToString() != "")
                {
                    model.marketid = int.Parse(reader["marketid"].ToString());
                }
                if (reader["markettitle"] != null && reader["markettitle"].ToString() != "")
                {
                    model.markettitle = reader["markettitle"].ToString();
                }
                if (reader["storeyid"] != null && reader["storeyid"].ToString() != "")
                {
                    model.storeyid = int.Parse(reader["storeyid"].ToString());
                }
                if (reader["storeytitle"] != null && reader["storeytitle"].ToString() != "")
                {
                    model.storeytitle = reader["storeytitle"].ToString();
                }
                if (reader["shopid"] != null && reader["shopid"].ToString() != "")
                {
                    model.shopid = int.Parse(reader["shopid"].ToString());
                }
                if (reader["shoptitle"] != null && reader["shoptitle"].ToString() != "")
                {
                    model.shoptitle = reader["shoptitle"].ToString();
                }
                if (reader["brandidlist"] != null && reader["brandidlist"].ToString() != "")
                {
                    model.brandidlist = reader["brandidlist"].ToString();
                }
                if (reader["brandtitlelist"] != null && reader["brandtitlelist"].ToString() != "")
                {
                    model.brandtitlelist = reader["brandtitlelist"].ToString();
                }
                if (reader["istop"] != null && reader["istop"].ToString() != "")
                {
                    model.istop = int.Parse(reader["istop"].ToString());
                }
                if (reader["isrecommend"] != null && reader["isrecommend"].ToString() != "")
                {
                    model.isrecommend = int.Parse(reader["isrecommend"].ToString());
                }
                if (reader["lev"] != null && reader["lev"].ToString() != "")
                {
                    model.lev = int.Parse(reader["lev"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["source"] != null && reader["source"].ToString() != "")
                {
                    model.source = int.Parse(reader["source"].ToString());
                }
                if (reader["PavilionId"] != null && reader["PavilionId"].ToString() != "")
                {
                    model.PavilionId = int.Parse(reader["PavilionId"].ToString());
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
        #endregion

        #region 获取楼层店铺列表        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMarketStoreyShop> GetMarketStoreyShopList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMarketStoreyShop> modelList = new List<EnMarketStoreyShop>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMarketStoreyShop, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMarketStoreyShop model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMarketStoreyShop();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["marketid"] != null && dt.Rows[n]["marketid"].ToString() != "")
                    {
                        model.marketid = int.Parse(dt.Rows[n]["marketid"].ToString());
                    }
                    if (dt.Rows[n]["markettitle"] != null && dt.Rows[n]["markettitle"].ToString() != "")
                    {
                        model.markettitle = dt.Rows[n]["markettitle"].ToString();
                    }
                    if (dt.Rows[n]["storeyid"] != null && dt.Rows[n]["storeyid"].ToString() != "")
                    {
                        model.storeyid = int.Parse(dt.Rows[n]["storeyid"].ToString());
                    }
                    if (dt.Rows[n]["storeytitle"] != null && dt.Rows[n]["storeytitle"].ToString() != "")
                    {
                        model.storeytitle = dt.Rows[n]["storeytitle"].ToString();
                    }
                    if (dt.Rows[n]["shopid"] != null && dt.Rows[n]["shopid"].ToString() != "")
                    {
                        model.shopid = int.Parse(dt.Rows[n]["shopid"].ToString());
                    }
                    if (dt.Rows[n]["shoptitle"] != null && dt.Rows[n]["shoptitle"].ToString() != "")
                    {
                        model.shoptitle = dt.Rows[n]["shoptitle"].ToString();
                    }
                    if (dt.Rows[n]["brandidlist"] != null && dt.Rows[n]["brandidlist"].ToString() != "")
                    {
                        model.brandidlist = dt.Rows[n]["brandidlist"].ToString();
                    }
                    if (dt.Rows[n]["brandtitlelist"] != null && dt.Rows[n]["brandtitlelist"].ToString() != "")
                    {
                        model.brandtitlelist = dt.Rows[n]["brandtitlelist"].ToString();
                    }
                    if (dt.Rows[n]["istop"] != null && dt.Rows[n]["istop"].ToString() != "")
                    {
                        model.istop = int.Parse(dt.Rows[n]["istop"].ToString());
                    }
                    if (dt.Rows[n]["isrecommend"] != null && dt.Rows[n]["isrecommend"].ToString() != "")
                    {
                        model.isrecommend = int.Parse(dt.Rows[n]["isrecommend"].ToString());
                    }
                    if (dt.Rows[n]["lev"] != null && dt.Rows[n]["lev"].ToString() != "")
                    {
                        model.lev = int.Parse(dt.Rows[n]["lev"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["lastedid"] != null && dt.Rows[n]["lastedid"].ToString() != "")
                    {
                        model.lastedid = int.Parse(dt.Rows[n]["lastedid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["createtime"] != null && dt.Rows[n]["createtime"].ToString() != "")
                    {
                        model.createtime = DateTime.Parse(dt.Rows[n]["createtime"].ToString());
                    }
                    if (dt.Rows[n]["position"] != null && dt.Rows[n]["position"].ToString() != "")
                    {
                        model.position = dt.Rows[n]["position"].ToString();
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus =int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["source"] != null && dt.Rows[n]["source"].ToString() != "")
                    {
                        model.source = int.Parse(dt.Rows[n]["source"].ToString());
                    }
                    if (dt.Rows[n]["PavilionId"] != null && dt.Rows[n]["PavilionId"].ToString() != "")
                    {
                        model.PavilionId = int.Parse(dt.Rows[n]["PavilionId"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region 删除楼层店铺   
        /// <summary>
        /// 删除楼层店铺
        /// </summary>
        /// <param name="marketId">卖场id</param>
        /// <param name="shopId">店铺id</param>
        /// <returns></returns>
        //public static int delMarketStoreyShop(int marketId, int shopId)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("delete  t_marketstoreyshop where marketid=@marketid and shopid=@shopid");
        //    strSql.Append("update  t_shop set marketid=0 where marketid=@marketid and id=@shopid");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@marketid", SqlDbType.Int,4),
        //            new SqlParameter("@shopid", SqlDbType.Int,4)
        //                                  };
        //    parameters[0].Value = marketId;
        //    parameters[1].Value = shopId;
        //    return DbHelper.ExecuteNonQuery(strSql.ToString());
        //}
        #endregion

    }
}

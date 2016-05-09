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
    public class Aggregations
    {

        //聚合信息
        public static List<EnWebAggregation> GetWebAggregationList(int PageIndex, int PageSize, string strWhere, string sortkey, string orderby, out int pageCount)
        {
            List<EnWebAggregation> list = new List<EnWebAggregation>();
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TVAggregation, PageIndex, PageSize, strWhere, sortkey, orderby, out pageCount);
            while (reader.Read())
            {
                EnWebAggregation model = new EnWebAggregation();
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["typethumb"] != null && reader["typethumb"].ToString() != "")
                {
                    model.typethumb = reader["typethumb"].ToString();
                }
                if (reader["typeurl"] != null && reader["typeurl"].ToString() != "")
                {
                    model.typeurl = reader["typeurl"].ToString();
                }
                if (reader["typetitle"] != null && reader["typetitle"].ToString() != "")
                {
                    model.typetitle = reader["typetitle"].ToString();
                }
                if (reader["parent"] != null && reader["parent"].ToString() != "")
                {
                    model.parent = int.Parse(reader["parent"].ToString());
                }
                if (reader["type"] != null && reader["type"].ToString() != "")
                {
                    model.type = int.Parse(reader["type"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["title1"] != null && reader["title1"].ToString() != "")
                {
                    model.title1 = reader["title1"].ToString();
                }
                if (reader["title2"] != null && reader["title2"].ToString() != "")
                {
                    model.title2 = reader["title2"].ToString();
                }
                if (reader["title3"] != null && reader["title3"].ToString() != "")
                {
                    model.title3 = reader["title3"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["thumbw"] != null && reader["thumbw"].ToString() != "")
                {
                    model.thumbw = int.Parse(reader["thumbw"].ToString());
                }
                if (reader["thumbh"] != null && reader["thumbh"].ToString() != "")
                {
                    model.thumbh = int.Parse(reader["thumbh"].ToString());
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["url"] != null && reader["url"].ToString() != "")
                {
                    model.url = reader["url"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["starttime"] != DBNull.Value && reader["starttime"].ToString() != "")
                {
                    model.starttime = DateTime.Parse(reader["starttime"].ToString());
                }
                if (reader["endtime"] != DBNull.Value && reader["endtime"].ToString() != "")
                {
                    model.endtime = DateTime.Parse(reader["endtime"].ToString());
                }
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;
        }


        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAggregation(EnAggregation model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_aggregation(");
                strSql.Append("type,title,title1,title2,title3,thumb,thumbw,thumbh,bannel,url,url1,url2,descript,sort,hits,lastedittime,createmid)");
                strSql.Append(" values (");
                strSql.Append("@type,@title,@title1,@title2,@title3,@thumb,@thumbw,@thumbh,@bannel,@url,@url1,@url2,@descript,@sort,@hits,@lastedittime,@createmid)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,120),
					new SqlParameter("@title1", SqlDbType.NVarChar,50),
					new SqlParameter("@title2", SqlDbType.NVarChar,50),
					new SqlParameter("@title3", SqlDbType.NVarChar,50),
					new SqlParameter("@thumb", SqlDbType.VarChar,50),
					new SqlParameter("@thumbw", SqlDbType.Int,4),
					new SqlParameter("@thumbh", SqlDbType.Int,4),
					new SqlParameter("@bannel", SqlDbType.VarChar,400),
					new SqlParameter("@url", SqlDbType.VarChar,50),
					new SqlParameter("@url1", SqlDbType.VarChar,50),
					new SqlParameter("@url2", SqlDbType.VarChar,50),
					new SqlParameter("@descript", SqlDbType.NVarChar,250),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@createmid", SqlDbType.Int,4)};
                parameters[0].Value = model.type;
                parameters[1].Value = model.title;
                parameters[2].Value = model.title1;
                parameters[3].Value = model.title2;
                parameters[4].Value = model.title3;
                parameters[5].Value = model.thumb;
                parameters[6].Value = model.thumbw;
                parameters[7].Value = model.thumbh;
                parameters[8].Value = model.bannel;
                parameters[9].Value = model.url;
                parameters[10].Value = model.url1;
                parameters[11].Value = model.url2;
                parameters[12].Value = model.descript;
                parameters[13].Value = model.sort;
                parameters[14].Value = model.hits;
                parameters[15].Value = model.lastedittime;
                parameters[16].Value = model.createmid;



                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_aggregation set ");
                strSql.Append("type=@type,");
                strSql.Append("title=@title,");
                strSql.Append("title1=@title1,");
                strSql.Append("title2=@title2,");
                strSql.Append("title3=@title3,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("thumbw=@thumbw,");
                strSql.Append("thumbh=@thumbh,");
                strSql.Append("bannel=@bannel,");
                strSql.Append("url=@url,");
                strSql.Append("url1=@url1,");
                strSql.Append("url2=@url2,");
                strSql.Append("descript=@descript,");
                strSql.Append("sort=@sort,");
                strSql.Append("hits=@hits,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("createmid=@createmid");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,120),
					new SqlParameter("@title1", SqlDbType.NVarChar,50),
					new SqlParameter("@title2", SqlDbType.NVarChar,50),
					new SqlParameter("@title3", SqlDbType.NVarChar,50),
					new SqlParameter("@thumb", SqlDbType.VarChar,50),
					new SqlParameter("@thumbw", SqlDbType.Int,4),
					new SqlParameter("@thumbh", SqlDbType.Int,4),
					new SqlParameter("@bannel", SqlDbType.VarChar,400),
					new SqlParameter("@url", SqlDbType.VarChar,50),
					new SqlParameter("@url1", SqlDbType.VarChar,50),
					new SqlParameter("@url2", SqlDbType.VarChar,50),
					new SqlParameter("@descript", SqlDbType.NVarChar,250),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.type;
                parameters[1].Value = model.title;
                parameters[2].Value = model.title1;
                parameters[3].Value = model.title2;
                parameters[4].Value = model.title3;
                parameters[5].Value = model.thumb;
                parameters[6].Value = model.thumbw;
                parameters[7].Value = model.thumbh;
                parameters[8].Value = model.bannel;
                parameters[9].Value = model.url;
                parameters[10].Value = model.url1;
                parameters[11].Value = model.url2;
                parameters[12].Value = model.descript;
                parameters[13].Value = model.sort;
                parameters[14].Value = model.hits;
                parameters[15].Value = model.lastedittime;
                parameters[16].Value = model.createmid;
                parameters[17].Value = model.id;

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
        public static EnAggregation GetAggregationInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Aggregation ");
            strSql.Append(strWhere);


            EnAggregation model = new EnAggregation();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["type"] != null && reader["type"].ToString() != "")
                {
                    model.type = int.Parse(reader["type"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["title1"] != null && reader["title1"].ToString() != "")
                {
                    model.title1 = reader["title1"].ToString();
                }
                if (reader["title2"] != null && reader["title2"].ToString() != "")
                {
                    model.title2 = reader["title2"].ToString();
                }
                if (reader["title3"] != null && reader["title3"].ToString() != "")
                {
                    model.title3 = reader["title3"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["thumbw"] != null && reader["thumbw"].ToString() != "")
                {
                    model.thumbw = int.Parse(reader["thumbw"].ToString());
                }
                if (reader["thumbh"] != null && reader["thumbh"].ToString() != "")
                {
                    model.thumbh = int.Parse(reader["thumbh"].ToString());
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["url"] != null && reader["url"].ToString() != "")
                {
                    model.url = reader["url"].ToString();
                }
                if (reader["url1"] != null && reader["url1"].ToString() != "")
                {
                    model.url1 = reader["url1"].ToString();
                }
                if (reader["url2"] != null && reader["url2"].ToString() != "")
                {
                    model.url2 = reader["url2"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
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
        public static List<EnAggregation> GetAggregationList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAggregation> modelList = new List<EnAggregation>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBAggregation, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnAggregation model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnAggregation();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = int.Parse(dt.Rows[n]["type"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["title1"] != null && dt.Rows[n]["title1"].ToString() != "")
                    {
                        model.title1 = dt.Rows[n]["title1"].ToString();
                    }
                    if (dt.Rows[n]["title2"] != null && dt.Rows[n]["title2"].ToString() != "")
                    {
                        model.title2 = dt.Rows[n]["title2"].ToString();
                    }
                    if (dt.Rows[n]["title3"] != null && dt.Rows[n]["title3"].ToString() != "")
                    {
                        model.title3 = dt.Rows[n]["title3"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["thumbw"] != null && dt.Rows[n]["thumbw"].ToString() != "")
                    {
                        model.thumbw = int.Parse(dt.Rows[n]["thumbw"].ToString());
                    }
                    if (dt.Rows[n]["thumbh"] != null && dt.Rows[n]["thumbh"].ToString() != "")
                    {
                        model.thumbh = int.Parse(dt.Rows[n]["thumbh"].ToString());
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["url"] != null && dt.Rows[n]["url"].ToString() != "")
                    {
                        model.url = dt.Rows[n]["url"].ToString();
                    }
                    if (dt.Rows[n]["url1"] != null && dt.Rows[n]["url1"].ToString() != "")
                    {
                        model.url1 = dt.Rows[n]["url1"].ToString();
                    }
                    if (dt.Rows[n]["url2"] != null && dt.Rows[n]["url2"].ToString() != "")
                    {
                        model.url2 = dt.Rows[n]["url2"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["hits"] != null && dt.Rows[n]["hits"].ToString() != "")
                    {
                        model.hits = int.Parse(dt.Rows[n]["hits"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["createmid"] != null && dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAggregationType(EnAggregationType model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_aggregationtype(");
                strSql.Append("parentid,title,title1,thumb,url,sort)");
                strSql.Append(" values (");
                strSql.Append("@parentid,@title,@title1,@thumb,@url,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,120),
					new SqlParameter("@title1", SqlDbType.NVarChar,50),
					new SqlParameter("@thumb", SqlDbType.VarChar,400),
					new SqlParameter("@url", SqlDbType.VarChar,100),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.parentid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.title1;
                parameters[3].Value = model.thumb;
                parameters[4].Value = model.url;
                parameters[5].Value = model.sort;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_aggregationtype set ");
                strSql.Append("parentid=@parentid,");
                strSql.Append("title=@title,");
                strSql.Append("title1=@title1,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("url=@url,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,120),
					new SqlParameter("@title1", SqlDbType.NVarChar,50),
					new SqlParameter("@thumb", SqlDbType.VarChar,400),
					new SqlParameter("@url", SqlDbType.VarChar,100),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.parentid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.title1;
                parameters[3].Value = model.thumb;
                parameters[4].Value = model.url;
                parameters[5].Value = model.sort;
                parameters[6].Value = model.id;

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
        public static EnAggregationType GetAggregationTypeInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_AggregationType ");
            strSql.Append(strWhere);


            EnAggregationType model = new EnAggregationType();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["parentid"] != null && reader["parentid"].ToString() != "")
                {
                    model.parentid = int.Parse(reader["parentid"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["title1"] != null && reader["title1"].ToString() != "")
                {
                    model.title1 = reader["title1"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["url"] != null && reader["url"].ToString() != "")
                {
                    model.url = reader["url"].ToString();
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
        public static List<EnAggregationType> GetAggregationTypeList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAggregationType> modelList = new List<EnAggregationType>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBAggregationType, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnAggregationType model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnAggregationType();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["parentid"] != null && dt.Rows[n]["parentid"].ToString() != "")
                    {
                        model.parentid = int.Parse(dt.Rows[n]["parentid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["title1"] != null && dt.Rows[n]["title1"].ToString() != "")
                    {
                        model.title1 = dt.Rows[n]["title1"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["url"] != null && dt.Rows[n]["url"].ToString() != "")
                    {
                        model.url = dt.Rows[n]["url"].ToString();
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


    }
}

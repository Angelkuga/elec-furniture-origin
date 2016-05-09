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
    public class MarketStoreys
    {

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMarketStorey(EnMarketStorey model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_marketstorey(");
                strSql.Append("marketid,markettitle,title,number,surface,logo,thumb,bannel,desimage,descript,keywords,template,hits,sort,lastedid,lastedittime)");
                strSql.Append(" values (");
                strSql.Append("@marketid,@markettitle,@title,@number,@surface,@logo,@thumb,@bannel,@desimage,@descript,@keywords,@template,@hits,@sort,@lastedid,@lastedittime)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@marketid", SqlDbType.Int,4),
					new SqlParameter("@markettitle", SqlDbType.NVarChar,50),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@number", SqlDbType.NVarChar,20),
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
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime)};
                parameters[0].Value = model.marketid;
                parameters[1].Value = model.markettitle;
                parameters[2].Value = model.title;
                parameters[3].Value = model.number;
                parameters[4].Value = model.surface;
                parameters[5].Value = model.logo;
                parameters[6].Value = model.thumb;
                parameters[7].Value = model.bannel;
                parameters[8].Value = model.desimage;
                parameters[9].Value = model.descript;
                parameters[10].Value = model.keywords;
                parameters[11].Value = model.template;
                parameters[12].Value = model.hits;
                parameters[13].Value = model.sort;
                parameters[14].Value = model.lastedid;
                parameters[15].Value = model.lastedittime;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_marketstorey set ");
                strSql.Append("marketid=@marketid,");
                strSql.Append("markettitle=@markettitle,");
                strSql.Append("title=@title,");
                strSql.Append("number=@number,");
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
                strSql.Append("lastedid=@lastedid,");
                strSql.Append("lastedittime=@lastedittime");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@marketid", SqlDbType.Int,4),
					new SqlParameter("@markettitle", SqlDbType.NVarChar,50),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@number", SqlDbType.NVarChar,20),
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
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.marketid;
                parameters[1].Value = model.markettitle;
                parameters[2].Value = model.title;
                parameters[3].Value = model.number;
                parameters[4].Value = model.surface;
                parameters[5].Value = model.logo;
                parameters[6].Value = model.thumb;
                parameters[7].Value = model.bannel;
                parameters[8].Value = model.desimage;
                parameters[9].Value = model.descript;
                parameters[10].Value = model.keywords;
                parameters[11].Value = model.template;
                parameters[12].Value = model.hits;
                parameters[13].Value = model.sort;
                parameters[14].Value = model.lastedid;
                parameters[15].Value = model.lastedittime;
                parameters[16].Value = model.id;

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
        public static EnMarketStorey GetMarketStoreyInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_MarketStorey ");
            strSql.Append(strWhere);


            EnMarketStorey model = new EnMarketStorey();
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
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["number"] != null && reader["number"].ToString() != "")
                {
                    model.number = reader["number"].ToString();
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
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
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
        public static List<EnMarketStorey> GetMarketStoreyList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMarketStorey> modelList = new List<EnMarketStorey>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMarketStorey, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMarketStorey model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMarketStorey();
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
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["number"] != null && dt.Rows[n]["number"].ToString() != "")
                    {
                        model.number = dt.Rows[n]["number"].ToString();
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
                    if (dt.Rows[n]["lastedid"] != null && dt.Rows[n]["lastedid"].ToString() != "")
                    {
                        model.lastedid = int.Parse(dt.Rows[n]["lastedid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

    }
}

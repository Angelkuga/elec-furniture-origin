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
    public class Configs
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditConfig(EnConfig model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_config(");
                strSql.Append("title,value,type,module,sort)");
                strSql.Append(" values (");
                strSql.Append("@title,@value,@type,@module,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,400),
					new SqlParameter("@value", SqlDbType.NVarChar,400),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@module", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.value;
                parameters[2].Value = model.type;
                parameters[3].Value = model.module;
                parameters[4].Value = model.sort;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_config set ");
                strSql.Append("title=@title,");
                strSql.Append("value=@value,");
                strSql.Append("type=@type,");
                strSql.Append("module=@module,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,400),
					new SqlParameter("@value", SqlDbType.NVarChar,400),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@module", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.value;
                parameters[2].Value = model.type;
                parameters[3].Value = model.module;
                parameters[4].Value = model.sort;
                parameters[5].Value = model.id;

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
        public static EnConfig GetConfigInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Config ");
            strSql.Append(strWhere);


            EnConfig model = new EnConfig();
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
                if (reader["value"] != null && reader["value"].ToString() != "")
                {
                    model.value = reader["value"].ToString();
                }
                if (reader["type"] != null && reader["type"].ToString() != "")
                {
                    model.type = int.Parse(reader["type"].ToString());
                }
                if (reader["module"] != null && reader["module"].ToString() != "")
                {
                    model.module = int.Parse(reader["module"].ToString());
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
        public static List<EnConfig> GetConfigList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnConfig> modelList = new List<EnConfig>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBConfig, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnConfig model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnConfig();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["value"] != null && dt.Rows[n]["value"].ToString() != "")
                    {
                        model.value = dt.Rows[n]["value"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = int.Parse(dt.Rows[n]["type"].ToString());
                    }
                    if (dt.Rows[n]["module"] != null && dt.Rows[n]["module"].ToString() != "")
                    {
                        model.module = int.Parse(dt.Rows[n]["module"].ToString());
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


        /// <summary>
        /// 获得数据列表
        /// Add:rafer
        /// Date:2012-5-14
        /// </summary>
        public static string GetConfigListNew(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            string StyleString = string.Empty;
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBConfig, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        if (dt.Rows[n]["title"] == null || string.IsNullOrEmpty(dt.Rows[n]["title"].ToString()) || StyleString.Contains(dt.Rows[n]["title"].ToString()))
                        {
                            continue;
                        }
                        if (n == 0)
                        {
                            StyleString = dt.Rows[n]["title"].ToString();
                        }
                        else
                        { StyleString += "&nbsp;" + dt.Rows[n]["title"].ToString(); }
                    }
                }
            }
            if (string.IsNullOrEmpty(StyleString))
            {
                StyleString = "暂未选择风格";
            }
            return StyleString;
        }

        #endregion


        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditConfigType(EnConfigType model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_configtype(");
                strSql.Append("title,mark,letter,type,sort,count,descript)");
                strSql.Append(" values (");
                strSql.Append("@title,@mark,@letter,@type,@sort,@count,@descript)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@mark", SqlDbType.VarChar,20),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@type", SqlDbType.VarChar,100),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@descript", SqlDbType.NVarChar,400)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.mark;
                parameters[2].Value = model.letter;
                parameters[3].Value = model.type;
                parameters[4].Value = model.sort;
                parameters[5].Value = model.count;
                parameters[6].Value = model.descript;



                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_configtype set ");
                strSql.Append("title=@title,");
                strSql.Append("mark=@mark,");
                strSql.Append("letter=@letter,");
                strSql.Append("type=@type,");
                strSql.Append("sort=@sort,");
                strSql.Append("count=@count,");
                strSql.Append("descript=@descript");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@mark", SqlDbType.VarChar,20),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@type", SqlDbType.VarChar,100),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@descript", SqlDbType.NVarChar,400),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.mark;
                parameters[2].Value = model.letter;
                parameters[3].Value = model.type;
                parameters[4].Value = model.sort;
                parameters[5].Value = model.count;
                parameters[6].Value = model.descript;
                parameters[7].Value = model.id;

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
        public static EnConfigType GetConfigTypeInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_ConfigType ");
            strSql.Append(strWhere);


            EnConfigType model = new EnConfigType();
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
                if (reader["mark"] != null && reader["mark"].ToString() != "")
                {
                    model.mark = reader["mark"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["type"] != null && reader["type"].ToString() != "")
                {
                    model.type = reader["type"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["count"] != null && reader["count"].ToString() != "")
                {
                    model.count = int.Parse(reader["count"].ToString());
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
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
        public static List<EnConfigType> GetConfigTypeList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnConfigType> modelList = new List<EnConfigType>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBConfigType, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnConfigType model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnConfigType();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["mark"] != null && dt.Rows[n]["mark"].ToString() != "")
                    {
                        model.mark = dt.Rows[n]["mark"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = dt.Rows[n]["type"].ToString();
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["count"] != null && dt.Rows[n]["count"].ToString() != "")
                    {
                        model.count = int.Parse(dt.Rows[n]["count"].ToString());
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}

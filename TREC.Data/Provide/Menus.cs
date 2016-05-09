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
    public class Menus
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMenu(EnMenu model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_menu(");
                strSql.Append("title,type,mark,parent,lev,path,url,module,action,descript,sort)");
                strSql.Append(" values (");
                strSql.Append("@title,@type,@mark,@parent,@lev,@path,@url,@module,@action,@descript,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@mark", SqlDbType.VarChar,50),
					new SqlParameter("@parent", SqlDbType.Int,4),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@path", SqlDbType.VarChar,50),
					new SqlParameter("@url", SqlDbType.VarChar,400),
					new SqlParameter("@module", SqlDbType.Int,4),
					new SqlParameter("@action", SqlDbType.Int,4),
					new SqlParameter("@descript", SqlDbType.NVarChar,800),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.type;
                parameters[2].Value = model.mark;
                parameters[3].Value = model.parent;
                parameters[4].Value = model.lev;
                parameters[5].Value = model.path;
                parameters[6].Value = model.url;
                parameters[7].Value = model.module;
                parameters[8].Value = model.action;
                parameters[9].Value = model.descript;
                parameters[10].Value = model.sort;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_menu set ");
                strSql.Append("title=@title,");
                strSql.Append("type=@type,");
                strSql.Append("mark=@mark,");
                strSql.Append("parent=@parent,");
                strSql.Append("lev=@lev,");
                strSql.Append("path=@path,");
                strSql.Append("url=@url,");
                strSql.Append("module=@module,");
                strSql.Append("action=@action,");
                strSql.Append("descript=@descript,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@mark", SqlDbType.VarChar,50),
					new SqlParameter("@parent", SqlDbType.Int,4),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@path", SqlDbType.VarChar,50),
					new SqlParameter("@url", SqlDbType.VarChar,400),
					new SqlParameter("@module", SqlDbType.Int,4),
					new SqlParameter("@action", SqlDbType.Int,4),
					new SqlParameter("@descript", SqlDbType.NVarChar,800),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.type;
                parameters[2].Value = model.mark;
                parameters[3].Value = model.parent;
                parameters[4].Value = model.lev;
                parameters[5].Value = model.path;
                parameters[6].Value = model.url;
                parameters[7].Value = model.module;
                parameters[8].Value = model.action;
                parameters[9].Value = model.descript;
                parameters[10].Value = model.sort;
                parameters[11].Value = model.id;

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
        public static EnMenu GetMenuInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Menu ");
            strSql.Append(strWhere);


            EnMenu model = new EnMenu();
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
                if (reader["type"] != null && reader["type"].ToString() != "")
                {
                    model.type = reader["type"].ToString();
                }
                if (reader["mark"] != null && reader["mark"].ToString() != "")
                {
                    model.mark = reader["mark"].ToString();
                }
                if (reader["parent"] != null && reader["parent"].ToString() != "")
                {
                    model.parent = int.Parse(reader["parent"].ToString());
                }
                if (reader["lev"] != null && reader["lev"].ToString() != "")
                {
                    model.lev = int.Parse(reader["lev"].ToString());
                }
                if (reader["path"] != null && reader["path"].ToString() != "")
                {
                    model.path = reader["path"].ToString();
                }
                if (reader["url"] != null && reader["url"].ToString() != "")
                {
                    model.url = reader["url"].ToString();
                }
                if (reader["module"] != null && reader["module"].ToString() != "")
                {
                    model.module = int.Parse(reader["module"].ToString());
                }
                if (reader["action"] != null && reader["action"].ToString() != "")
                {
                    model.action = int.Parse(reader["action"].ToString());
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
        public static List<EnMenu> GetMenuList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMenu> modelList = new List<EnMenu>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMenu, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMenu model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMenu();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = dt.Rows[n]["type"].ToString();
                    }
                    if (dt.Rows[n]["mark"] != null && dt.Rows[n]["mark"].ToString() != "")
                    {
                        model.mark = dt.Rows[n]["mark"].ToString();
                    }
                    if (dt.Rows[n]["parent"] != null && dt.Rows[n]["parent"].ToString() != "")
                    {
                        model.parent = int.Parse(dt.Rows[n]["parent"].ToString());
                    }
                    if (dt.Rows[n]["lev"] != null && dt.Rows[n]["lev"].ToString() != "")
                    {
                        model.lev = int.Parse(dt.Rows[n]["lev"].ToString());
                    }
                    if (dt.Rows[n]["path"] != null && dt.Rows[n]["path"].ToString() != "")
                    {
                        model.path = dt.Rows[n]["path"].ToString();
                    }
                    if (dt.Rows[n]["url"] != null && dt.Rows[n]["url"].ToString() != "")
                    {
                        model.url = dt.Rows[n]["url"].ToString();
                    }
                    if (dt.Rows[n]["module"] != null && dt.Rows[n]["module"].ToString() != "")
                    {
                        model.module = int.Parse(dt.Rows[n]["module"].ToString());
                    }
                    if (dt.Rows[n]["action"] != null && dt.Rows[n]["action"].ToString() != "")
                    {
                        model.action = int.Parse(dt.Rows[n]["action"].ToString());
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


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMenu> GetMenuList(string filed,string strWhere,string sort)
        {
            List<EnMenu> modelList = new List<EnMenu>();
            DataTable dt = DataCommon.GetDataTable(TableName.TBMenu, "", strWhere, sort);
            if (dt.Rows.Count > 0)
            {
                EnMenu model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMenu();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = dt.Rows[n]["type"].ToString();
                    }
                    if (dt.Rows[n]["mark"] != null && dt.Rows[n]["mark"].ToString() != "")
                    {
                        model.mark = dt.Rows[n]["mark"].ToString();
                    }
                    if (dt.Rows[n]["parent"] != null && dt.Rows[n]["parent"].ToString() != "")
                    {
                        model.parent = int.Parse(dt.Rows[n]["parent"].ToString());
                    }
                    if (dt.Rows[n]["lev"] != null && dt.Rows[n]["lev"].ToString() != "")
                    {
                        model.lev = int.Parse(dt.Rows[n]["lev"].ToString());
                    }
                    if (dt.Rows[n]["path"] != null && dt.Rows[n]["path"].ToString() != "")
                    {
                        model.path = dt.Rows[n]["path"].ToString();
                    }
                    if (dt.Rows[n]["url"] != null && dt.Rows[n]["url"].ToString() != "")
                    {
                        model.url = dt.Rows[n]["url"].ToString();
                    }
                    if (dt.Rows[n]["module"] != null && dt.Rows[n]["module"].ToString() != "")
                    {
                        model.module = int.Parse(dt.Rows[n]["module"].ToString());
                    }
                    if (dt.Rows[n]["action"] != null && dt.Rows[n]["action"].ToString() != "")
                    {
                        model.action = int.Parse(dt.Rows[n]["action"].ToString());
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

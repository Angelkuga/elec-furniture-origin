using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TREC.Entity;
using System.Data;
using TRECommon;

namespace TREC.Data
{
    public class Links
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditLinks(EnLinks model)
        {
            if (model.Id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_links(");
                strSql.Append("[title],[linestatus],[link])");
                strSql.Append(" values (");
                strSql.Append("@title,@linestatus,@link)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
                    new SqlParameter("@link", SqlDbType.NText)};
                parameters[0].Value = model.Title;
                parameters[1].Value = model.Linestatus;
                parameters[2].Value = model.Link;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_links set ");
                strSql.Append("title=@title,");
                strSql.Append("link=@link,");
                strSql.Append("linestatus=@linestatus");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
                    new SqlParameter("@link", SqlDbType.NText),
                    new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.Title;
                parameters[1].Value = model.Linestatus;
                parameters[2].Value = model.Link;
                parameters[3].Value = model.Id;
                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.Id;
                }
            }

            return 0;

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnLinks GetLinksInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_links ");
            strSql.Append(strWhere);


            EnLinks model = new EnLinks();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.Id = int.Parse(reader["id"].ToString());
                }                
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.Title = reader["title"].ToString();
                }
                if (reader["link"] != null && reader["link"].ToString() != "")
                {
                    model.Link = reader["link"].ToString();
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.Linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["CreateTime"] != null && reader["CreateTime"].ToString() != "")
                {
                    model.Createtime = DateTime.Parse(reader["CreateTime"].ToString());
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
        /// 获得分页的数据列表
        /// </summary>
        public static List<EnLinks> GetLinksList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnLinks> modelList = new List<EnLinks>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBLink, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnLinks model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnLinks();

                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["link"] != null && dt.Rows[n]["link"].ToString() != "")
                    {
                        model.Link = dt.Rows[n]["link"].ToString();
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.Linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"] != null && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.Createtime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnLinks> GetLinksList(string filed, string strWhere, string sort)
        {
            List<EnLinks> modelList = new List<EnLinks>();
            DataTable dt = DataCommon.GetDataTable(TableName.TBLink, filed, strWhere, sort);
            if (dt.Rows.Count > 0)
            {
                EnLinks model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnLinks();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["link"] != null && dt.Rows[n]["link"].ToString() != "")
                    {
                        model.Link = dt.Rows[n]["link"].ToString();
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.Linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"] != null && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.Createtime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion
    }
}

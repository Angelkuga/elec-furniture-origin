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
    public class Logs
    {

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditLog(EnLog model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_log(");
                strSql.Append("modeule,action,operateid,operatename,title,lastedittime)");
                strSql.Append(" values (");
                strSql.Append("@modeule,@action,@operateid,@operatename,@title,@lastedittime)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@modeule", SqlDbType.Int,4),
					new SqlParameter("@action", SqlDbType.Int,4),
					new SqlParameter("@operateid", SqlDbType.Int,4),
					new SqlParameter("@operatename", SqlDbType.NVarChar,60),
					new SqlParameter("@title", SqlDbType.NVarChar,380),
					new SqlParameter("@lastedittime", SqlDbType.DateTime)};
                parameters[0].Value = model.modeule;
                parameters[1].Value = model.action;
                parameters[2].Value = model.operateid;
                parameters[3].Value = model.operatename;
                parameters[4].Value = model.title;
                parameters[5].Value = model.lastedittime;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_log set ");
                strSql.Append("modeule=@modeule,");
                strSql.Append("action=@action,");
                strSql.Append("operateid=@operateid,");
                strSql.Append("operatename=@operatename,");
                strSql.Append("title=@title,");
                strSql.Append("lastedittime=@lastedittime");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@modeule", SqlDbType.Int,4),
					new SqlParameter("@action", SqlDbType.Int,4),
					new SqlParameter("@operateid", SqlDbType.Int,4),
					new SqlParameter("@operatename", SqlDbType.NVarChar,60),
					new SqlParameter("@title", SqlDbType.NVarChar,380),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.modeule;
                parameters[1].Value = model.action;
                parameters[2].Value = model.operateid;
                parameters[3].Value = model.operatename;
                parameters[4].Value = model.title;
                parameters[5].Value = model.lastedittime;
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
        public static EnLog GetLogInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Log ");
            strSql.Append(strWhere);


            EnLog model = new EnLog();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["modeule"] != null && reader["modeule"].ToString() != "")
                {
                    model.modeule = int.Parse(reader["modeule"].ToString());
                }
                if (reader["action"] != null && reader["action"].ToString() != "")
                {
                    model.action = int.Parse(reader["action"].ToString());
                }
                if (reader["operateid"] != null && reader["operateid"].ToString() != "")
                {
                    model.operateid = int.Parse(reader["operateid"].ToString());
                }
                if (reader["operatename"] != null && reader["operatename"].ToString() != "")
                {
                    model.operatename = reader["operatename"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
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
        public static List<EnLog> GetLogList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnLog> modelList = new List<EnLog>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBLog, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnLog model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnLog();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["modeule"] != null && dt.Rows[n]["modeule"].ToString() != "")
                    {
                        model.modeule = int.Parse(dt.Rows[n]["modeule"].ToString());
                    }
                    if (dt.Rows[n]["action"] != null && dt.Rows[n]["action"].ToString() != "")
                    {
                        model.action = int.Parse(dt.Rows[n]["action"].ToString());
                    }
                    if (dt.Rows[n]["operateid"] != null && dt.Rows[n]["operateid"].ToString() != "")
                    {
                        model.operateid = int.Parse(dt.Rows[n]["operateid"].ToString());
                    }
                    if (dt.Rows[n]["operatename"] != null && dt.Rows[n]["operatename"].ToString() != "")
                    {
                        model.operatename = dt.Rows[n]["operatename"].ToString();
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
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

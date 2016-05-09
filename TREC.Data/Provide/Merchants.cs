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
    public class Merchants
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMerchants(EnMerchants model)
        {
            if (model.Id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_Merchants(");
                strSql.Append("[Cid],[brandid],[title],[descript],[auditstatus],[linestatus],[lastedittime])");
                strSql.Append(" values (");
                strSql.Append("@Cid,@brandid,@title,@descript,@auditstatus,@linestatus,@lastedittime)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@brandid", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
                    new SqlParameter("@lastedittime", SqlDbType.DateTime)};
                parameters[0].Value = model.Cid;
                parameters[1].Value = model.Brandid;
                parameters[2].Value = model.Title;
                parameters[3].Value = model.Descript;
                parameters[4].Value = model.Auditstatus;
                parameters[5].Value = model.Linestatus;
                parameters[6].Value = model.Lastedittime;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_Merchants set ");
                strSql.Append("brandid=@brandid,");
                strSql.Append("title=@title,");
                strSql.Append("descript=@descript,");
                strSql.Append("auditstatus=@auditstatus,");
                strSql.Append("linestatus=@linestatus,");
                strSql.Append("lastedittime=@lastedittime");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@brandid", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@lastedittime", SqlDbType.DateTime)};
                parameters[0].Value = model.Brandid;
                parameters[1].Value = model.Title;
                parameters[2].Value = model.Descript;
                parameters[3].Value = model.Auditstatus;
                parameters[4].Value = model.Linestatus;
                parameters[5].Value = model.Id;
                parameters[6].Value = model.Lastedittime;
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
        public static EnMerchants GetMerchantsInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Merchants ");
            strSql.Append(strWhere);


            EnMerchants model = new EnMerchants();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.Id = int.Parse(reader["id"].ToString());
                }
                if (reader["Cid"] != null && reader["Cid"].ToString() != "")
                {
                    model.Cid = int.Parse(reader["Cid"].ToString());
                }
                if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                {
                    model.Brandid = reader["brandid"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.Title = reader["title"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.Descript = reader["descript"].ToString();
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.Auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.Linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["CreateTime"] != null && reader["CreateTime"].ToString() != "")
                {
                    model.Createtime = DateTime.Parse(reader["CreateTime"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.Lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["Membercount"] != null && reader["Membercount"].ToString() != "")
                {
                    model.Membercount = int.Parse(reader["Membercount"].ToString());
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
        public static List<EnMerchants> GetMerchantsList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMerchants> modelList = new List<EnMerchants>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMerchants, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMerchants model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMerchants();

                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["Cid"] != null && dt.Rows[n]["Cid"].ToString() != "")
                    {
                        model.Cid = int.Parse(dt.Rows[n]["Cid"].ToString());
                    }
                    if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
                    {
                        model.Brandid = dt.Rows[n]["brandid"].ToString();
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.Descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.Auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.Linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"] != null && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.Createtime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.Lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["Membercount"] != null && dt.Rows[n]["Membercount"].ToString() != "")
                    {
                        model.Membercount = int.Parse(dt.Rows[n]["Membercount"].ToString());
                    }
                    
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMerchants> GetMerchantsList(string filed, string strWhere, string sort)
        {
            List<EnMerchants> modelList = new List<EnMerchants>();
            DataTable dt = DataCommon.GetDataTable(TableName.TBMerchants, filed, strWhere, sort);
            if (dt.Rows.Count > 0)
            {
                EnMerchants model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMerchants();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["Cid"] != null && dt.Rows[n]["Cid"].ToString() != "")
                    {
                        model.Cid = int.Parse(dt.Rows[n]["Cid"].ToString());
                    }
                    if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
                    {
                        model.Brandid = dt.Rows[n]["brandid"].ToString();
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.Descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.Auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.Linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"] != null && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.Createtime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.Lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["Membercount"] != null && dt.Rows[n]["Membercount"].ToString() != "")
                    {
                        model.Membercount = int.Parse(dt.Rows[n]["Membercount"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMerchantsCount(EnMerchants model)
        {
            if (model.Id != 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_Merchants set ");
                strSql.Append("membercount=membercount+@membercount");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@membercount", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.Membercount;
                parameters[1].Value = model.Id;
                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.Id;
                }
            }

            return 0;

        }

        //列表
        public static List<EnWebMerchants> GetWebMerchantsList(int PageIndex, int PageSize, string strWhere, string sortkey, string ordertype, out int pageCount)
        {
            List<EnWebMerchants> list = new List<EnWebMerchants>();
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TVMerchantsList, PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);
            while (reader.Read())
            {
                EnWebMerchants model = new EnWebMerchants();
                if (reader["companyxml"] != null && reader["companyxml"].ToString() != "")
                {
                    model.Companyxml = reader["companyxml"].ToString();
                }
                if (reader["brandxml"] != null && reader["brandxml"].ToString() != "")
                {
                    model.Brandxml = reader["brandxml"].ToString();
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.Id = int.Parse(reader["id"].ToString());
                }
                if (reader["Cid"] != null && reader["Cid"].ToString() != "")
                {
                    model.Cid = int.Parse(reader["Cid"].ToString());
                }
                if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                {
                    model.Brandid = reader["brandid"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.Title = reader["title"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.Descript = reader["descript"].ToString();
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.Auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.Linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["CreateTime"] != null && reader["CreateTime"].ToString() != "")
                {
                    model.Createtime = DateTime.Parse(reader["CreateTime"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.Lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["Membercount"] != null && reader["Membercount"].ToString() != "")
                {
                    model.Membercount = int.Parse(reader["Membercount"].ToString());
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

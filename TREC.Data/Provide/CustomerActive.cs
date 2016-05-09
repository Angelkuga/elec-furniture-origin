using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TRECommon;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace TREC.Data
{
    /// <summary>
    /// 用户激活记录类
    /// </summary>
    public class CustomerActive
    {

        /// <summary>
        /// 更新消费用户激活对像
        /// </summary>
        public static int EditCustomer(EnCustomerActive model)
        {
            if (model.Id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into [t_customeractive](");
                strSql.Append("atext,acode,atype,createtime,astatus)");
                strSql.Append(" values (");
                strSql.Append("@atext,@acode,@atype,getdate(),@astatus)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@atext",model.AText),
                    new SqlParameter("@acode",model.ACode),
                    new SqlParameter("@atype",model.AType),
                    new SqlParameter("@astatus",model.AStatus) 
                                            };
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update [t_customeractive] set ");
                strSql.Append("atext=@atext,acode=@acode,atype=@atype,astatus=@astatus");
                strSql.Append(" where  id=@id");
                SqlParameter[] parameters = {
                    new SqlParameter("@id",model.Id),
                    new SqlParameter("@atext",model.AText),
                    new SqlParameter("@acode",model.ACode),
                    new SqlParameter("@atype",model.AType),
                    new SqlParameter("@astatus",model.AStatus)
                                            };
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            return 0;
        }

        /// <summary>
        /// 更具sql条件获取消费用户激活对象
        /// </summary>
        /// <param name="strWhere">where条件(要写where关键字)</param>
        /// <returns></returns>
        public static EnCustomerActive GetCustomerActive(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [t_customeractive] ");
            strSql.Append(strWhere);


            EnCustomerActive model = new EnCustomerActive();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != DBNull.Value && reader["id"].ToString() != "")
                {
                    model.Id = int.Parse(reader["id"].ToString());
                }
                if (reader["ACode"] != DBNull.Value && reader["ACode"].ToString() != "")
                {
                    model.ACode = reader["ACode"].ToString();
                }
                if (reader["CreateTime"] != DBNull.Value && reader["CreateTime"].ToString() != "")
                {
                    model.CreateTime = Convert.ToDateTime(reader["CreateTime"].ToString());
                }
                if (reader["AText"] != DBNull.Value && reader["AText"].ToString() != "")
                {
                    model.AText = reader["AText"].ToString();
                }
                if (reader["AType"] != DBNull.Value && reader["AType"].ToString() != "")
                {
                    model.AType = int.Parse(reader["AType"].ToString());
                }
                if (reader["AStatus"] != DBNull.Value && reader["AStatus"].ToString() != "")
                {
                    model.AStatus = int.Parse(reader["AStatus"].ToString());
                }
                if (!reader.IsClosed)
                {
                    reader.Close();

                }
                return model;
            }
            else
            {
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 消费用户激活分页数据
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="strWhere">条件</param>
        /// <param name="pagecount">总页数</param>
        /// <returns></returns>
        public static List<EnCustomerActive> GetCustomerActiveList(int pageindex, int pagesize, string strWhere, out int pagecount)
        {
            List<EnCustomerActive> modelList = new List<EnCustomerActive>();
            DataTable dt = DataCommon.GetPageDataTable("t_customeractive", pageindex, pagesize, strWhere, "", 1, out pagecount);
            if (dt.Rows.Count > 0)
            {
                EnCustomerActive model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnCustomerActive();
                    if (dt.Rows[n]["id"] != DBNull.Value && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["ACode"] != DBNull.Value && dt.Rows[n]["ACode"].ToString() != "")
                    {
                        model.ACode = (dt.Rows[n]["ACode"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"] != DBNull.Value && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = Convert.ToDateTime(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["AText"] != DBNull.Value && dt.Rows[n]["AText"].ToString() != "")
                    {
                        model.AText = dt.Rows[n]["AText"].ToString();
                    }
                    if (dt.Rows[n]["AType"] != DBNull.Value && dt.Rows[n]["AType"].ToString() != "")
                    {
                        model.AType = int.Parse(dt.Rows[n]["AType"].ToString());
                    }
                    if (dt.Rows[n]["AStatus"] != DBNull.Value && dt.Rows[n]["AStatus"].ToString() != "")
                    {
                        model.AStatus = int.Parse(dt.Rows[n]["AStatus"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 更具集团id获取卖场集团对象
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static EnCustomerActive GetCustomerActiveById(int Id)
        {
            return GetCustomerActive(string.Format(" where id = {0} ", Id));
        }
    }
}

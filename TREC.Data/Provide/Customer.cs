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
    /// 消费用户 数据操作类
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 更新消费用户对像
        /// </summary>
        public static int EditCustomer(EnCustomer model)
        {
            if (model.Id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into [t_customer](");
                strSql.Append("uname,upassword,unametype,ustatus,regtime,regip)");
                strSql.Append(" values (");
                strSql.Append("@uname,@upassword,@unametype,@ustatus,getdate(),@regip)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@uname",model.UName),
                    new SqlParameter("@upassword",model.UPassword),
                    new SqlParameter("@unametype",model.UNameType),
                    new SqlParameter("@ustatus",model.UStatus),
                    new SqlParameter("@regip",model.RegIP)
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
                strSql.Append("update [t_customer] set ");
                strSql.Append("uname=@uname,upassword=@upassword,unametype=@unametype,ustatus=@ustatus,regip=@regip");
                strSql.Append(" where  id=@id");
                SqlParameter[] parameters = {
                    new SqlParameter("@id",model.Id),
                    new SqlParameter("@uname",model.UName),
                    new SqlParameter("@upassword",model.UPassword),
                    new SqlParameter("@unametype",model.UNameType),
                    new SqlParameter("@ustatus",model.UStatus),
                    new SqlParameter("@regip",model.RegIP)
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
        /// 更具sql条件获取消费用户对象
        /// </summary>
        /// <param name="strWhere">where条件(要写where关键字)</param>
        /// <returns></returns>
        public static EnCustomer GetCustomer(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [t_customer] ");
            strSql.Append(strWhere);


            EnCustomer model = new EnCustomer();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != DBNull.Value && reader["id"].ToString() != "")
                {
                    model.Id = int.Parse(reader["id"].ToString());
                }
                if (reader["RegIP"] != DBNull.Value && reader["RegIP"].ToString() != "")
                {
                    model.RegIP = reader["RegIP"].ToString();
                }
                if (reader["Regtime"] != DBNull.Value && reader["Regtime"].ToString() != "")
                {
                    model.Regtime = Convert.ToDateTime(reader["Regtime"].ToString());
                }
                if (reader["UName"] != DBNull.Value && reader["UName"].ToString() != "")
                {
                    model.UName = reader["UName"].ToString();
                }
                if (reader["UNameType"] != DBNull.Value && reader["UNameType"].ToString() != "")
                {
                    model.UNameType = int.Parse(reader["UNameType"].ToString());
                }
                if (reader["UPassword"] != DBNull.Value && reader["UPassword"].ToString() != "")
                {
                    model.UPassword = reader["UPassword"].ToString();
                }
                if (reader["UStatus"] != DBNull.Value && reader["UStatus"].ToString() != "")
                {
                    model.UStatus = int.Parse(reader["UStatus"].ToString());
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
        /// 消费用户登录
        /// </summary>
        /// <param name="uname">用户名 手机或mail</param>
        /// <param name="upwd">密码md5加密后</param>
        /// <param name="utype">账号类型 1 手机 2 mail</param>
        /// <returns></returns>
        public static EnCustomer LoginCustomer(string uname, string upwd, int utype = 1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [t_customer] ");
            strSql.Append(" where unametype=@unametype and uname=@uname and upassword=@upassword");
            SqlParameter[] para = new SqlParameter[]{
                    new SqlParameter("@unametype",utype),
                    new SqlParameter("@uname",uname),
                    new SqlParameter("@upassword",upwd)
                };
            EnCustomer model = new EnCustomer();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString(), para);

            if (reader.Read())
            {
                if (reader["id"] != DBNull.Value && reader["id"].ToString() != "")
                {
                    model.Id = int.Parse(reader["id"].ToString());
                }
                if (reader["RegIP"] != DBNull.Value && reader["RegIP"].ToString() != "")
                {
                    model.RegIP = reader["RegIP"].ToString();
                }
                if (reader["Regtime"] != DBNull.Value && reader["Regtime"].ToString() != "")
                {
                    model.Regtime = Convert.ToDateTime(reader["Regtime"].ToString());
                }
                if (reader["UName"] != DBNull.Value && reader["UName"].ToString() != "")
                {
                    model.UName = reader["UName"].ToString();
                }
                if (reader["UNameType"] != DBNull.Value && reader["UNameType"].ToString() != "")
                {
                    model.UNameType = int.Parse(reader["UNameType"].ToString());
                }
                if (reader["UPassword"] != DBNull.Value && reader["UPassword"].ToString() != "")
                {
                    model.UPassword = reader["UPassword"].ToString();
                }
                if (reader["UStatus"] != DBNull.Value && reader["UStatus"].ToString() != "")
                {
                    model.UStatus = int.Parse(reader["UStatus"].ToString());
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
        /// 消费用户分页数据
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="strWhere">条件</param>
        /// <param name="pagecount">总页数</param>
        /// <returns></returns>
        public static List<EnCustomer> GetCustomerList(int pageindex, int pagesize, string strWhere, out int pagecount)
        {
            List<EnCustomer> modelList = new List<EnCustomer>();
            DataTable dt = DataCommon.GetPageDataTable("t_customer", pageindex, pagesize, strWhere, "", 1, out pagecount);
            if (dt.Rows.Count > 0)
            {
                EnCustomer model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnCustomer();
                    if (dt.Rows[n]["id"] != DBNull.Value && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["RegIP"] != DBNull.Value && dt.Rows[n]["RegIP"].ToString() != "")
                    {
                        model.RegIP = (dt.Rows[n]["RegIP"].ToString());
                    }
                    if (dt.Rows[n]["Regtime"] != DBNull.Value && dt.Rows[n]["Regtime"].ToString() != "")
                    {
                        model.Regtime = Convert.ToDateTime(dt.Rows[n]["Regtime"].ToString());
                    }
                    if (dt.Rows[n]["UName"] != DBNull.Value && dt.Rows[n]["UName"].ToString() != "")
                    {
                        model.UName = dt.Rows[n]["UName"].ToString();
                    }
                    if (dt.Rows[n]["UNameType"] != DBNull.Value && dt.Rows[n]["UNameType"].ToString() != "")
                    {
                        model.UNameType = int.Parse(dt.Rows[n]["UNameType"].ToString());
                    }
                    if (dt.Rows[n]["UPassword"] != DBNull.Value && dt.Rows[n]["UPassword"].ToString() != "")
                    {
                        model.UPassword = dt.Rows[n]["UPassword"].ToString();
                    }
                    if (dt.Rows[n]["UStatus"] != DBNull.Value && dt.Rows[n]["UStatus"].ToString() != "")
                    {
                        model.UStatus = int.Parse(dt.Rows[n]["UStatus"].ToString());
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
        public static EnCustomer GetCustomerById(int customerId)
        {
            return GetCustomer(string.Format(" where id = {0} ", customerId));
        }
    }
}

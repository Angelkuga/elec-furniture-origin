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
    public class PayMent
    {
        /// <summary>
        /// Insert PayMent
        /// </summary>
        public static int InsertPayMent(EnPayMent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_PayMent(");
            strSql.Append("OrderCode,Price,Mid,Types,Bank)");
            strSql.Append(" values (");
            strSql.Append("@OrderCode,@Price,@Mid,@Types,@Bank)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Price", SqlDbType.Decimal),
					new SqlParameter("@Mid", SqlDbType.Int,4),
					new SqlParameter("@Types", SqlDbType.Int,4),
                     new SqlParameter("@Bank", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.OrderCode;
            parameters[1].Value = model.Price;
            parameters[2].Value = model.Mid;
            parameters[3].Value = model.Types;
            parameters[4].Value = model.Bank;
            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj != null)
            {
                return TypeConverter.ObjectToInt(obj);
            }

            return 0;
        }

        /// <summary>
        /// Insert PayMentLog
        /// </summary>
        public static int InsertPayMentLog(EnPayMent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_PayMentLog(");
            strSql.Append("OrderCode,Price,Mid,Types,Bank,islook)");
            strSql.Append(" values (");
            strSql.Append("@OrderCode,@Price,@Mid,@Types,@Bank,@islook)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Price", SqlDbType.Decimal),
					new SqlParameter("@Mid", SqlDbType.Int,4),
					new SqlParameter("@Types", SqlDbType.Int,4),
                    new SqlParameter("@Bank", SqlDbType.NVarChar,20),
                    new SqlParameter("@islook", SqlDbType.Bit)};
            parameters[0].Value = model.OrderCode;
            parameters[1].Value = model.Price;
            parameters[2].Value = model.Mid;
            parameters[3].Value = model.Types;
            parameters[4].Value = model.Bank;
            parameters[5].Value = model.Types == 0;
            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj != null)
            {
                return TypeConverter.ObjectToInt(obj);
            }

            return 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnPayMent GetPayMent(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_PayMent ");
            strSql.Append(strWhere);

            EnPayMent model = new EnPayMent();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());
            if (reader.Read())
            {
                if (reader["OrderCode"] != null && reader["OrderCode"].ToString() != "")
                {
                    model.OrderCode = reader["OrderCode"].ToString();
                }
                if (reader["Price"] != null && reader["Price"].ToString() != "")
                {
                    model.Price = TypeConverter.StrToDeimal(reader["Price"].ToString());
                }
                if (reader["Mid"] != null && reader["Mid"].ToString() != "")
                {
                    model.Mid = TypeConverter.StrToInt(reader["Mid"].ToString(), 0);
                }
                if (reader["Types"] != null && reader["Types"].ToString() != "")
                {
                    model.Types = TypeConverter.StrToInt(reader["Types"].ToString(), 0);
                }
                if (reader["Bank"] != null && reader["Bank"].ToString() != "")
                {
                    model.Bank = reader["Bank"].ToString();
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
        /// 清楚PayMen对应的对象
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int DeletePayMent(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_PayMent ");
            strSql.Append(strWhere);
            int reader = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());

            return reader;
        }
    }
}

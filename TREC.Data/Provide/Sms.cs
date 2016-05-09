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
    public class Sms
    {
        /// <summary>
        /// 更新SMS
        /// </summary>
        public static int EditSms(EnSms sms)
        {
            if (sms.Id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("INSERT INTO t_sms(");
                strSql.Append("sms_phone,sms_content,sms_number_quantity,sms_status,sms_send_time,sms_return_string,sms_return_number,sms_msgid,sms_balance_money");
                strSql.Append(")VALUES (");
                strSql.Append("@sms_phone,@sms_content,@sms_number_quantity,@sms_status,@sms_send_time,@sms_return_string,@sms_return_number,@sms_msgid,@sms_balance_money");
                strSql.Append(");select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@sms_phone", SqlDbType.NVarChar,1000),
					new SqlParameter("@sms_content", SqlDbType.VarChar,250),
					new SqlParameter("@sms_number_quantity", SqlDbType.Int),
					new SqlParameter("@sms_status", SqlDbType.Bit),
					new SqlParameter("@sms_send_time", SqlDbType.DateTime),
					new SqlParameter("@sms_return_string", SqlDbType.NVarChar,1000),
					new SqlParameter("@sms_return_number", SqlDbType.Int),
					new SqlParameter("@sms_msgid", SqlDbType.BigInt),
					new SqlParameter("@sms_balance_money", SqlDbType.Money)};
                parameters[0].Value = sms.Sms_phone;
                parameters[1].Value = sms.Sms_content;
                parameters[2].Value = sms.Sms_number_quantity;
                parameters[3].Value = sms.Sms_status;
                parameters[4].Value = sms.Sms_send_time;
                parameters[5].Value = sms.Sms_return_string;
                parameters[6].Value = sms.Sms_return_number;
                parameters[7].Value = sms.Sms_msgid;
                parameters[8].Value = sms.Sms_balance_money;

                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE t_sms SET ");
                strSql.Append("sms_phone = @sms_phone");
                strSql.Append(",sms_content = @sms_content");
                strSql.Append(",sms_number_quantity = @sms_number_quantity");
                strSql.Append(",sms_status = @sms_status");
                strSql.Append(",sms_send_time = @sms_send_time");
                strSql.Append(",sms_return_string = @sms_return_string");
                strSql.Append(",sms_return_number = @sms_return_number");
                strSql.Append(",sms_msgid = @sms_msgid");
                strSql.Append(",sms_balance_money = @sms_balance_money");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@sms_phone", SqlDbType.NVarChar,1000),
					new SqlParameter("@sms_content", SqlDbType.VarChar,250),
					new SqlParameter("@sms_number_quantity", SqlDbType.Int),
					new SqlParameter("@sms_status", SqlDbType.Bit),
					new SqlParameter("@sms_send_time", SqlDbType.DateTime),
					new SqlParameter("@sms_return_string", SqlDbType.NVarChar,1000),
					new SqlParameter("@sms_return_number", SqlDbType.Int),
					new SqlParameter("@sms_msgid", SqlDbType.BigInt),
					new SqlParameter("@sms_balance_money", SqlDbType.Money),
					new SqlParameter("@id", SqlDbType.Int)};
                parameters[0].Value = sms.Sms_phone;
                parameters[1].Value = sms.Sms_content;
                parameters[2].Value = sms.Sms_number_quantity;
                parameters[3].Value = sms.Sms_status;
                parameters[4].Value = sms.Sms_send_time;
                parameters[5].Value = sms.Sms_return_string;
                parameters[6].Value = sms.Sms_return_number;
                parameters[7].Value = sms.Sms_msgid;
                parameters[8].Value = sms.Sms_balance_money;
                parameters[9].Value = sms.Id;

                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return sms.Id;
                }
            }
            return 0;
        }


        public static int DeleteSms(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE t_sms where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int)};
            parameters[0].Value = id;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public static int DeleteSmsByList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE t_sms where id in (" + idlist + ")");
            return DbHelper.ExecuteNonQuery(strSql.ToString());
        }

        /// <summary>
        /// 得到单个SMS对象
        /// </summary>
        public static EnSms GetSmsInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_sms ");
            strSql.Append(strWhere);

            EnSms sms = new EnSms();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    sms.Id = int.Parse(reader["id"].ToString());
                }
                if (reader["sms_phone"] != null && reader["sms_phone"].ToString() != "")
                {
                    sms.Sms_phone = reader["sms_phone"].ToString();
                }
                if (reader["sms_content"] != null && reader["sms_content"].ToString() != "")
                {
                    sms.Sms_content = reader["sms_content"].ToString();
                }
                if (reader["sms_number_quantity"] != null && reader["sms_number_quantity"].ToString() != "")
                {
                    sms.Sms_number_quantity = int.Parse(reader["sms_number_quantity"].ToString());
                }
                if (reader["sms_status"] != null && reader["sms_status"].ToString() != "")
                {
                    sms.Sms_status = bool.Parse(reader["sms_status"].ToString());
                }
                if (reader["sms_send_time"] != null && reader["sms_send_time"].ToString() != "")
                {
                    sms.Sms_send_time = DateTime.Parse(reader["sms_send_time"].ToString());
                }
                if (reader["sms_return_string"] != null && reader["sms_return_string"].ToString() != "")
                {
                    sms.Sms_return_string = reader["sms_return_string"].ToString();
                }
                if (reader["sms_return_number"] != null && reader["sms_return_number"].ToString() != "")
                {
                    sms.Sms_return_number = int.Parse(reader["sms_return_number"].ToString());
                }
                if (reader["sms_msgid"] != null && reader["sms_msgid"].ToString() != "")
                {
                    sms.Sms_msgid = long.Parse(reader["sms_msgid"].ToString());
                }
                if (reader["sms_balance_money"] != null && reader["sms_balance_money"].ToString() != "")
                {
                    sms.Sms_balance_money = decimal.Parse(reader["sms_balance_money"].ToString());
                }

                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return sms;
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
        public static List<EnSms> GetSmsList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnSms> smsList = new List<EnSms>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBSms, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnSms sms;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sms = new EnSms();
                    if (dt.Rows[i]["id"] != null && dt.Rows[i]["id"].ToString() != "")
                    {
                        sms.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    }
                    if (dt.Rows[i]["sms_phone"] != null && dt.Rows[i]["sms_phone"].ToString() != "")
                    {
                        sms.Sms_phone = dt.Rows[i]["sms_phone"].ToString();
                    }
                    if (dt.Rows[i]["sms_content"] != null && dt.Rows[i]["sms_content"].ToString() != "")
                    {
                        sms.Sms_content = dt.Rows[i]["sms_content"].ToString();
                    }
                    if (dt.Rows[i]["sms_number_quantity"] != null && dt.Rows[i]["sms_number_quantity"].ToString() != "")
                    {
                        sms.Sms_number_quantity = int.Parse(dt.Rows[i]["sms_number_quantity"].ToString());
                    }
                    if (dt.Rows[i]["sms_status"] != null && dt.Rows[i]["sms_status"].ToString() != "")
                    {
                        sms.Sms_status = bool.Parse(dt.Rows[i]["sms_status"].ToString());
                    }
                    if (dt.Rows[i]["sms_send_time"] != null && dt.Rows[i]["sms_send_time"].ToString() != "")
                    {
                        sms.Sms_send_time = DateTime.Parse(dt.Rows[i]["sms_send_time"].ToString());
                    }
                    if (dt.Rows[i]["sms_return_string"] != null && dt.Rows[i]["sms_return_string"].ToString() != "")
                    {
                        sms.Sms_return_string = dt.Rows[i]["sms_return_string"].ToString();
                    }
                    if (dt.Rows[i]["sms_return_number"] != null && dt.Rows[i]["sms_return_number"].ToString() != "")
                    {
                        sms.Sms_return_number = int.Parse(dt.Rows[i]["sms_return_number"].ToString());
                    }
                    if (dt.Rows[i]["sms_msgid"] != null && dt.Rows[i]["sms_msgid"].ToString() != "")
                    {
                        sms.Sms_msgid = long.Parse(dt.Rows[i]["sms_msgid"].ToString());
                    }
                    if (dt.Rows[i]["sms_balance_money"] != null && dt.Rows[i]["sms_balance_money"].ToString() != "")
                    {
                        sms.Sms_balance_money = decimal.Parse(dt.Rows[i]["sms_balance_money"].ToString());
                    }
                    smsList.Add(sms);
                }
            }
            return smsList;
        }

        


    }
}

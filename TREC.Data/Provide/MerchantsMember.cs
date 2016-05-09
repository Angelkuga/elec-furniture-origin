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
    public class MerchantsMember
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMerchantsMember(EnMerchantsMember model)
        {
            if (model.Id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_MerchantsMember(");
                strSql.Append("[Cid],[MerchantId],[Name],[Phone],[CityCode],[descript])");
                strSql.Append(" values (");
                strSql.Append("@Cid,@MerchantId,@Name,@Phone,@CityCode,@descript)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@Cid",  SqlDbType.Int,4),
					new SqlParameter("@MerchantId", SqlDbType.Int,4),
					new SqlParameter("@Name",SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@CityCode",SqlDbType.VarChar,50),
					new SqlParameter("@descript", SqlDbType.NText)};
                parameters[0].Value = model.Cid;
                parameters[1].Value = model.MerchantId;
                parameters[2].Value = model.Name;
                parameters[3].Value = model.Phone;
                parameters[4].Value = model.CityCode;
                parameters[5].Value = model.Descript;

                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_MerchantsMember set ");
                strSql.Append("MerchantId=@MerchantId,");
                strSql.Append("Name=@Name,");
                strSql.Append("Phone=@Phone,");
                strSql.Append("CityCode=@CityCode,");
                strSql.Append("descript=@descript");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@MerchantId", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@CityCode", SqlDbType.VarChar,50),
					new SqlParameter("@descript", SqlDbType.NText),
                    new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.MerchantId;
                parameters[1].Value = model.Name;
                parameters[2].Value = model.Phone;
                parameters[3].Value = model.CityCode;
                parameters[4].Value = model.Descript;
                parameters[5].Value = model.Id;
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
        public static EnMerchantsMember GetMerchantsMemberInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_MerchantsMember ");
            strSql.Append(strWhere);


            EnMerchantsMember model = new EnMerchantsMember();
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
                if (reader["MerchantId"] != null && reader["MerchantId"].ToString() != "")
                {
                    model.MerchantId = int.Parse(reader["MerchantId"].ToString());
                }
                if (reader["Name"] != null && reader["Name"].ToString() != "")
                {
                    model.Name = reader["Name"].ToString();
                }
                if (reader["Phone"] != null && reader["Phone"].ToString() != "")
                {
                    model.Phone = reader["Phone"].ToString();
                }
                if (reader["CityCode"] != null && reader["CityCode"].ToString() != "")
                {
                    model.CityCode = reader["CityCode"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.Descript = reader["descript"].ToString();
                }
                if (reader["CreateTime"] != null && reader["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(reader["CreateTime"].ToString());
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
        public static List<EnMerchantsMember> GetMerchantsMemberList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMerchantsMember> modelList = new List<EnMerchantsMember>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMerchantsMember, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMerchantsMember model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMerchantsMember();

                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["Cid"] != null && dt.Rows[n]["Cid"].ToString() != "")
                    {
                        model.Cid = int.Parse(dt.Rows[n]["Cid"].ToString());
                    }
                    if (dt.Rows[n]["MerchantId"] != null && dt.Rows[n]["MerchantId"].ToString() != "")
                    {
                        model.MerchantId = int.Parse(dt.Rows[n]["MerchantId"].ToString());
                    }
                    if (dt.Rows[n]["Name"] != null && dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.Name = dt.Rows[n]["Name"].ToString();
                    }
                    if (dt.Rows[n]["Phone"] != null && dt.Rows[n]["Phone"].ToString() != "")
                    {
                        model.Phone = dt.Rows[n]["Phone"].ToString();
                    }
                    if (dt.Rows[n]["CityCode"] != null && dt.Rows[n]["CityCode"].ToString() != "")
                    {
                        model.CityCode = dt.Rows[n]["CityCode"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.Descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["CreateTime"] != null && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMerchantsMember> GetMerchantsMemberList(string filed, string strWhere, string sort)
        {
            List<EnMerchantsMember> modelList = new List<EnMerchantsMember>();
            DataTable dt = DataCommon.GetDataTable(TableName.TBMerchantsMember, filed, strWhere, sort);
            if (dt.Rows.Count > 0)
            {
                EnMerchantsMember model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMerchantsMember();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["Cid"] != null && dt.Rows[n]["Cid"].ToString() != "")
                    {
                        model.Cid = int.Parse(dt.Rows[n]["Cid"].ToString());
                    }
                    if (dt.Rows[n]["MerchantId"] != null && dt.Rows[n]["MerchantId"].ToString() != "")
                    {
                        model.MerchantId = int.Parse(dt.Rows[n]["MerchantId"].ToString());
                    }
                    if (dt.Rows[n]["Name"] != null && dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.Name = dt.Rows[n]["Name"].ToString();
                    }
                    if (dt.Rows[n]["Phone"] != null && dt.Rows[n]["Phone"].ToString() != "")
                    {
                        model.Phone = dt.Rows[n]["Phone"].ToString();
                    }
                    if (dt.Rows[n]["CityCode"] != null && dt.Rows[n]["CityCode"].ToString() != "")
                    {
                        model.CityCode = dt.Rows[n]["CityCode"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.Descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["CreateTime"] != null && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion
    }
}

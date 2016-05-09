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
    public class MsgCollection
    {
        /// <summary>
        /// Modify MsgCollection
        /// </summary>
        public static int ModifyMsgCollection(EnMsgCollection model)
        {
            StringBuilder strSql = new StringBuilder();
            if (model.Id <= 0)
            {
                strSql.Append("insert into t_MsgCollection(");
                strSql.Append("Name,Contact,Code,useraddress,msginfo,ProdID,MID,ProdCon,BrandId,BrandName)");
                strSql.Append(" values (");
                strSql.Append("@Name,@Contact,@Code,@useraddress,@msginfo,@ProdID,@MID,@ProdCon,@BrandId,@BrandName)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Contact", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.VarChar,40),
                    new SqlParameter("@useraddress", SqlDbType.NVarChar,500),
                    new SqlParameter("@msginfo", SqlDbType.NVarChar,500),
                    new SqlParameter("@ProdID", SqlDbType.Int),
                    new SqlParameter("@MID", SqlDbType.Int),
                    new SqlParameter("@ProdCon", SqlDbType.Int),
                     new SqlParameter("@BrandId", SqlDbType.Int),
                      new SqlParameter("@BrandName", SqlDbType.NChar,300)
                                            };
                parameters[0].Value = model.Name;
                parameters[1].Value = model.Contact;
                parameters[2].Value = model.Code;
                parameters[3].Value = model.UserAddress;
                parameters[4].Value = model.MsgInfo;
                parameters[5].Value = model.ProdID;
                parameters[6].Value = model.MID;
                parameters[7].Value = model.ProdCon;
                parameters[8].Value = model.BrandId;
                parameters[9].Value = model.BrandName;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                strSql.Append("update t_MsgCollection set ");
                strSql.Append("Name=@Name,");
                strSql.Append("Contact=@Contact,");
                strSql.Append("Code=@Code,");
                strSql.Append("useraddress=@useraddress,");
                strSql.Append("msginfo=@msginfo,");
                strSql.Append("ProdID=@ProdID,");
                strSql.Append("MID=@MID,");
                strSql.Append("ProdCon=@ProdCon,");
                strSql.Append("BrandId=@BrandId,");
                strSql.Append("BrandName=@BrandName");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Contact", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.VarChar,40),					
                    new SqlParameter("@ProdID", SqlDbType.Int),
                    new SqlParameter("@msginfo", SqlDbType.NVarChar,500),
                    new SqlParameter("@useraddress", SqlDbType.NVarChar,500),
                    new SqlParameter("@MID", SqlDbType.Int),
                    new SqlParameter("@ProdCon", SqlDbType.Int),
                    new SqlParameter("@id", SqlDbType.Int),
                    new SqlParameter("@BrandId", SqlDbType.Int),
                    new SqlParameter("@BrandName", SqlDbType.NVarChar,300)
                                            };
                parameters[0].Value = model.Name;
                parameters[1].Value = model.Contact;
                parameters[2].Value = model.Code;
                parameters[3].Value = model.ProdID;
                parameters[4].Value = model.MsgInfo;
                parameters[5].Value = model.UserAddress;
                parameters[6].Value = model.MID;
                parameters[7].Value = model.ProdCon;
                parameters[8].Value = model.Id;
                parameters[9].Value = model.BrandId;
                parameters[10].Value = model.BrandName;
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
        public static EnMsgCollection GetMsgCollectionInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_MsgCollection ");
            strSql.Append(strWhere);

            EnMsgCollection model = new EnMsgCollection();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());
            if (reader.Read())
            {
                if (reader["Name"] != null && reader["Name"].ToString() != "")
                {
                    model.Name = reader["Name"].ToString();
                }
                if (reader["Contact"] != null && reader["Contact"].ToString() != "")
                {
                    model.Contact = reader["Contact"].ToString();
                }
                if (reader["Code"] != null && reader["Code"].ToString() != "")
                {
                    model.Code = reader["Code"].ToString();
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.Id = TypeConverter.StrToInt(reader["id"].ToString(), 0);
                }
                if (reader["ProdID"] != null && reader["ProdID"].ToString() != "")
                {
                    model.ProdID = TypeConverter.StrToInt(reader["ProdID"].ToString(), 0);
                }
                if (reader["MID"] != null && reader["MID"].ToString() != "")
                {
                    model.MID = TypeConverter.StrToInt(reader["MID"].ToString(), 0);
                }
                if (reader["MsgInfo"] != null && reader["MsgInfo"].ToString() != "")
                {
                    model.MsgInfo = reader["MsgInfo"].ToString();
                }
                if (reader["UserAddress"] != null && reader["UserAddress"].ToString() != "")
                {
                    model.UserAddress = reader["UserAddress"].ToString();
                }
                if (reader["ProdCon"] != null && reader["ProdCon"].ToString() != "")
                {
                    model.ProdCon = TypeConverter.StrToInt(reader["ProdCon"].ToString(), 0);
                }
                if (reader["BrandId"] != null && reader["BrandId"].ToString() != "")
                {
                    model.BrandId = TypeConverter.StrToInt(reader["BrandId"].ToString(), 0);
                }
                if (reader["BrandName"] != null && reader["BrandName"].ToString() != "")
                {
                    model.BrandName = reader["BrandName"].ToString();
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
        /// 清除MsgCollection对应的对象
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int DeleteMsgCollection(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_MsgCollection ");
            strSql.Append(strWhere);
            int reader = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());

            return reader;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMsgCollection> GetMsgCollectionList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMsgCollection> smsList = new List<EnMsgCollection>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMsgCollection, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMsgCollection model;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new EnMsgCollection();
                    if (dt.Rows[i]["id"] != null && dt.Rows[i]["id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    }
                    if (dt.Rows[i]["Name"] != null && dt.Rows[i]["Name"].ToString() != "")
                    {
                        model.Name = dt.Rows[i]["Name"].ToString();
                    }
                    if (dt.Rows[i]["Contact"] != null && dt.Rows[i]["Contact"].ToString() != "")
                    {
                        model.Contact = dt.Rows[i]["Contact"].ToString();
                    }
                    if (dt.Rows[i]["Code"] != null && dt.Rows[i]["Code"].ToString() != "")
                    {
                        model.Code = dt.Rows[i]["Code"].ToString();
                    }
                    if (dt.Rows[i]["CreateTime"] != null && dt.Rows[i]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[i]["CreateTime"].ToString());
                    }
                    if (dt.Rows[i]["ProdID"] != null && dt.Rows[i]["ProdID"].ToString() != "")
                    {
                        model.ProdID = int.Parse(dt.Rows[i]["ProdID"].ToString());
                    }
                    if (dt.Rows[i]["MID"] != null && dt.Rows[i]["MID"].ToString() != "")
                    {
                        model.MID = int.Parse(dt.Rows[i]["MID"].ToString());
                    }
                    if (dt.Rows[i]["MsgInfo"] != null && dt.Rows[i]["MsgInfo"].ToString() != "")
                    {
                        model.MsgInfo = dt.Rows[i]["MsgInfo"].ToString();
                    }
                    if (dt.Rows[i]["UserAddress"] != null && dt.Rows[i]["UserAddress"].ToString() != "")
                    {
                        model.UserAddress = dt.Rows[i]["UserAddress"].ToString();
                    }
                    if (dt.Rows[i]["ProdCon"] != null && dt.Rows[i]["ProdCon"].ToString() != "")
                    {
                        model.ProdCon = int.Parse(dt.Rows[i]["ProdCon"].ToString());
                    }
                    smsList.Add(model);
                }
            }
            return smsList;
        }

        /// <summary>
        /// 得到符合条件的报名数
        /// </summary>
        public static int GetMsgCollectionCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  count(0) from t_MsgCollection ");
            strSql.Append(strWhere);

            EnMsgCollection model = new EnMsgCollection();
            Object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
            return int.Parse(obj.ToString());
        }
    }
}

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
    public class Administrators
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAdmin(EnAdmin model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_admin(");
                strSql.Append("name,password,displayname,question,answer,email,phone,areacode,address,logincount,islock,lastmodule,createdate,lastactivitydate)");
                strSql.Append(" values (");
                strSql.Append("@name,@password,@displayname,@question,@answer,@email,@phone,@areacode,@address,@logincount,@islock,@lastmodule,@createdate,@lastactivitydate)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.Char,32),
					new SqlParameter("@displayname", SqlDbType.NVarChar,25),
					new SqlParameter("@question", SqlDbType.NVarChar,30),
					new SqlParameter("@answer", SqlDbType.NVarChar,30),
					new SqlParameter("@email", SqlDbType.VarChar,30),
					new SqlParameter("@phone", SqlDbType.VarChar,30),
					new SqlParameter("@areacode", SqlDbType.VarChar,10),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
					new SqlParameter("@logincount", SqlDbType.Int,4),
					new SqlParameter("@islock", SqlDbType.Int,4),
					new SqlParameter("@lastmodule", SqlDbType.NVarChar,50),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@lastactivitydate", SqlDbType.DateTime)};
                parameters[0].Value = model.name;
                parameters[1].Value = model.password;
                parameters[2].Value = model.displayname;
                parameters[3].Value = model.question;
                parameters[4].Value = model.answer;
                parameters[5].Value = model.email;
                parameters[6].Value = model.phone;
                parameters[7].Value = model.areacode;
                parameters[8].Value = model.address;
                parameters[9].Value = model.logincount;
                parameters[10].Value = model.islock;
                parameters[11].Value = model.lastmodule;
                parameters[12].Value = model.createdate;
                parameters[13].Value = model.lastactivitydate;

                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_admin set ");
                strSql.Append("name=@name,");
                strSql.Append("password=@password,");
                strSql.Append("displayname=@displayname,");
                strSql.Append("question=@question,");
                strSql.Append("answer=@answer,");
                strSql.Append("email=@email,");
                strSql.Append("phone=@phone,");
                strSql.Append("areacode=@areacode,");
                strSql.Append("address=@address,");
                strSql.Append("logincount=@logincount,");
                strSql.Append("islock=@islock,");
                strSql.Append("lastmodule=@lastmodule,");
                strSql.Append("createdate=@createdate,");
                strSql.Append("lastactivitydate=@lastactivitydate");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.Char,32),
					new SqlParameter("@displayname", SqlDbType.NVarChar,25),
					new SqlParameter("@question", SqlDbType.NVarChar,30),
					new SqlParameter("@answer", SqlDbType.NVarChar,30),
					new SqlParameter("@email", SqlDbType.VarChar,30),
					new SqlParameter("@phone", SqlDbType.VarChar,30),
					new SqlParameter("@areacode", SqlDbType.VarChar,10),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
					new SqlParameter("@logincount", SqlDbType.Int,4),
					new SqlParameter("@islock", SqlDbType.Int,4),
					new SqlParameter("@lastmodule", SqlDbType.NVarChar,50),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@lastactivitydate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.name;
                parameters[1].Value = model.password;
                parameters[2].Value = model.displayname;
                parameters[3].Value = model.question;
                parameters[4].Value = model.answer;
                parameters[5].Value = model.email;
                parameters[6].Value = model.phone;
                parameters[7].Value = model.areacode;
                parameters[8].Value = model.address;
                parameters[9].Value = model.logincount;
                parameters[10].Value = model.islock;
                parameters[11].Value = model.lastmodule;
                parameters[12].Value = model.createdate;
                parameters[13].Value = model.lastactivitydate;
                parameters[14].Value = model.id;

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
        public static EnAdmin GetAdminInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_admin ");
            strSql.Append(strWhere);


            EnAdmin model = new EnAdmin();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["name"] != null && reader["name"].ToString() != "")
                {
                    model.name = reader["name"].ToString();
                }
                if (reader["password"] != null && reader["password"].ToString() != "")
                {
                    model.password = reader["password"].ToString();
                }
                if (reader["displayname"] != null && reader["displayname"].ToString() != "")
                {
                    model.displayname = reader["displayname"].ToString();
                }
                if (reader["question"] != null && reader["question"].ToString() != "")
                {
                    model.question = reader["question"].ToString();
                }
                if (reader["answer"] != null && reader["answer"].ToString() != "")
                {
                    model.answer = reader["answer"].ToString();
                }
                if (reader["email"] != null && reader["email"].ToString() != "")
                {
                    model.email = reader["email"].ToString();
                }
                if (reader["phone"] != null && reader["phone"].ToString() != "")
                {
                    model.phone = reader["phone"].ToString();
                }
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
                }
                if (reader["logincount"] != null && reader["logincount"].ToString() != "")
                {
                    model.logincount = int.Parse(reader["logincount"].ToString());
                }
                if (reader["islock"] != null && reader["islock"].ToString() != "")
                {
                    model.islock = int.Parse(reader["islock"].ToString());
                }
                if (reader["lastmodule"] != null && reader["lastmodule"].ToString() != "")
                {
                    model.lastmodule = reader["lastmodule"].ToString();
                }
                if (reader["createdate"] != null && reader["createdate"].ToString() != "")
                {
                    model.createdate = DateTime.Parse(reader["createdate"].ToString());
                }
                if (reader["lastactivitydate"] != null && reader["lastactivitydate"].ToString() != "")
                {
                    model.lastactivitydate = DateTime.Parse(reader["lastactivitydate"].ToString());
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
        public static List<EnAdmin> GetAdminList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAdmin> modelList = new List<EnAdmin>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBAdmin, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnAdmin model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnAdmin();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["name"] != null && dt.Rows[n]["name"].ToString() != "")
                    {
                        model.name = dt.Rows[n]["name"].ToString();
                    }
                    if (dt.Rows[n]["password"] != null && dt.Rows[n]["password"].ToString() != "")
                    {
                        model.password = dt.Rows[n]["password"].ToString();
                    }
                    if (dt.Rows[n]["displayname"] != null && dt.Rows[n]["displayname"].ToString() != "")
                    {
                        model.displayname = dt.Rows[n]["displayname"].ToString();
                    }
                    if (dt.Rows[n]["question"] != null && dt.Rows[n]["question"].ToString() != "")
                    {
                        model.question = dt.Rows[n]["question"].ToString();
                    }
                    if (dt.Rows[n]["answer"] != null && dt.Rows[n]["answer"].ToString() != "")
                    {
                        model.answer = dt.Rows[n]["answer"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["areacode"] != null && dt.Rows[n]["areacode"].ToString() != "")
                    {
                        model.areacode = dt.Rows[n]["areacode"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["logincount"] != null && dt.Rows[n]["logincount"].ToString() != "")
                    {
                        model.logincount = int.Parse(dt.Rows[n]["logincount"].ToString());
                    }
                    if (dt.Rows[n]["islock"] != null && dt.Rows[n]["islock"].ToString() != "")
                    {
                        model.islock = int.Parse(dt.Rows[n]["islock"].ToString());
                    }
                    if (dt.Rows[n]["lastmodule"] != null && dt.Rows[n]["lastmodule"].ToString() != "")
                    {
                        model.lastmodule = dt.Rows[n]["lastmodule"].ToString();
                    }
                    if (dt.Rows[n]["createdate"] != null && dt.Rows[n]["createdate"].ToString() != "")
                    {
                        model.createdate = DateTime.Parse(dt.Rows[n]["createdate"].ToString());
                    }
                    if (dt.Rows[n]["lastactivitydate"] != null && dt.Rows[n]["lastactivitydate"].ToString() != "")
                    {
                        model.lastactivitydate = DateTime.Parse(dt.Rows[n]["lastactivitydate"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion
    }
}

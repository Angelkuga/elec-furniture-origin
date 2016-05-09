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
    public class Areas
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditArea(EnArea model)
        {
            if (model.areacode == "0" || model.areacode == "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_area(");
                strSql.Append("areacode,parentcode,areaname,areazipcode,grouparea)");
                strSql.Append(" values (");
                strSql.Append("@areacode,@parentcode,@areaname,@areazipcode,@grouparea)");
                SqlParameter[] parameters = {
					new SqlParameter("@areacode", SqlDbType.VarChar,10),
					new SqlParameter("@parentcode", SqlDbType.VarChar,10),
					new SqlParameter("@areaname", SqlDbType.NVarChar,25),
					new SqlParameter("@areazipcode", SqlDbType.VarChar,10),
					new SqlParameter("@grouparea", SqlDbType.NVarChar,25)};
                parameters[0].Value = model.areacode;
                parameters[1].Value = model.parentcode;
                parameters[2].Value = model.areaname;
                parameters[3].Value = model.areazipcode;
                parameters[4].Value = model.grouparea;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_area set ");
                strSql.Append("parentcode=@parentcode,");
                strSql.Append("areaname=@areaname,");
                strSql.Append("areazipcode=@areazipcode,");
                strSql.Append("grouparea=@grouparea");
                strSql.Append(" where areacode=@areacode");
                SqlParameter[] parameters = {
					new SqlParameter("@parentcode", SqlDbType.VarChar,10),
					new SqlParameter("@areaname", SqlDbType.NVarChar,25),
					new SqlParameter("@areazipcode", SqlDbType.VarChar,10),
					new SqlParameter("@grouparea", SqlDbType.NVarChar,25),
					new SqlParameter("@areacode", SqlDbType.VarChar,10)};
                parameters[0].Value = model.parentcode;
                parameters[1].Value = model.areaname;
                parameters[2].Value = model.areazipcode;
                parameters[3].Value = model.grouparea;
                parameters[4].Value = model.areacode;


                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return int.Parse(model.areacode);
                }
            }

            return 0;

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnArea GetAreaInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Area ");
            strSql.Append(strWhere);


            EnArea model = new EnArea();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["parentcode"] != null && reader["parentcode"].ToString() != "")
                {
                    model.parentcode = reader["parentcode"].ToString();
                }
                if (reader["areaname"] != null && reader["areaname"].ToString() != "")
                {
                    model.areaname = reader["areaname"].ToString();
                }
                if (reader["areazipcode"] != null && reader["areazipcode"].ToString() != "")
                {
                    model.areazipcode = reader["areazipcode"].ToString();
                }
                if (reader["grouparea"] != null && reader["grouparea"].ToString() != "")
                {
                    model.grouparea = reader["grouparea"].ToString();
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
        public static List<EnArea> GetAreaList(string strWhere)
        {
            List<EnArea> modelList = new List<EnArea>();
            DataTable dt = DataCommon.GetDataTable(TableName.TBArea, "", strWhere, "");
            if (dt.Rows.Count > 0)
            {
                EnArea model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnArea();
                    if (dt.Rows[n]["areacode"] != null && dt.Rows[n]["areacode"].ToString() != "")
                    {
                        model.areacode = dt.Rows[n]["areacode"].ToString();
                    }
                    if (dt.Rows[n]["parentcode"] != null && dt.Rows[n]["parentcode"].ToString() != "")
                    {
                        model.parentcode = dt.Rows[n]["parentcode"].ToString();
                    }
                    if (dt.Rows[n]["areaname"] != null && dt.Rows[n]["areaname"].ToString() != "")
                    {
                        model.areaname = dt.Rows[n]["areaname"].ToString();
                    }
                    if (dt.Rows[n]["areazipcode"] != null && dt.Rows[n]["areazipcode"].ToString() != "")
                    {
                        model.areazipcode = dt.Rows[n]["areazipcode"].ToString();
                    }
                    if (dt.Rows[n]["grouparea"] != null && dt.Rows[n]["grouparea"].ToString() != "")
                    {
                        model.grouparea = dt.Rows[n]["grouparea"].ToString();
                    }
                    if (dt.Columns.Contains("zxs")) {
                        if (dt.Rows[n]["zxs"] != null && dt.Rows[n]["zxs"].ToString() != "")
                        {
                            model.zxs = Convert.ToInt32(dt.Rows[n]["zxs"]);
                        }
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        /// <summary>
        /// 2015-01-30 shen
        /// </summary>
        /// <returns></returns>
        public static List<EnArea> GetAreaList()
        {
            //DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT areacode,parentcode,areaname,areazipcode,grouparea FROM dbo.t_area ").Tables[0];

            List<EnArea> list = new List<EnArea>();
            EnArea info = new EnArea();

            List<EnArea> temp = GetAreaList(" where  1=1 ");
            //省,直辖市 
            list = temp.FindAll(x => x.parentcode == "0").ToList();

            foreach (EnArea item in list)
            {
                //市辖区&县
                //市
                item.CityList = temp.FindAll(x => x.parentcode == item.areacode).ToList();
                item.CityList.Sort(delegate(EnArea type1, EnArea type2) { return type1.sort.CompareTo(type2.sort); });

                foreach (EnArea city in item.CityList)
                {
                    //市辖区名/县名
                    //市辖区&县
                    city.CountyList = temp.FindAll(x => x.parentcode == city.areacode).ToList();
                    city.CountyList.Sort(delegate(EnArea type1, EnArea type2) { return type1.sort.CompareTo(type2.sort); });
                }

            }
            return list;
        }

        public static List<EnArea> listaddress = new List<EnArea>();

        private static void Address(List<EnArea> temp, string areacode)
        {
            foreach (EnArea item in temp)
            {
                if (item.parentcode == areacode)
                {

                    if (temp.Find(x => x.parentcode == item.areacode) != null)
                    {
                        Address(temp, item.areacode);
                    }
                    else
                        listaddress.Add(item);
                }


            }
        }

    }
}

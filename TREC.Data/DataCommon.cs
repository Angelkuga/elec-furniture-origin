using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace TREC.Data
{
    public class DataCommon
    {
        public DataCommon() { }

        #region 是否存在  && 获取行数 && 最大值/ID

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">where '' 条件</param>
        /// <returns>如果存在返回数量count(1)</returns>
        public static int Exists(string tableName, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + tableName + strWhere);

            return Convert.ToInt32(DbHelper.ExecuteScalar(strSql.ToString()));
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">where '' 条件</param>
        /// <returns>如果存在返回数量count(1)</returns>
        public static int Exists(string tableName, string strWhere, params DbParameter[] commandParameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + tableName + strWhere);

            return Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), commandParameters));
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="where">where ''  条件</param>
        /// <returns></returns>
        public static int GetRecordCout(string tableName, string where)
        {
            return Exists(tableName, where);
        }


        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">条件 where '' </param>
        /// <param name="field">字段</param>
        /// <returns>返回结果.ToStirng()</returns>
        public static string GetMaxValue(string tableName, string strWhere, string field)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max([");
            if (field == "")
                strSql.Append(" id ");
            else
                strSql.Append(field);
            strSql.Append("]) from " + tableName + strWhere);
            object obj = DbHelper.ExecuteScalar(strSql.ToString());
            return obj == null ? "" : obj.ToString();

        }

        /// <summary>
        /// 获取最大ID（如果空则为1）
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">条件 where '' </param>
        /// <param name="field">字段</param>
        /// <returns>如果存在返回数量count(1)</returns>
        public static int GetMaxID(string tableName, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(ID)+1 from " + tableName + strWhere);
            object obj = DbHelper.ExecuteScalar(strSql.ToString());
            return obj == DBNull.Value ? 1 : Convert.ToInt32(obj);

        }


        #endregion

        #region 行操作  （增,删,改）


        /// <summary>
        /// 删除行 by strWhere 
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">Where ='' </param>
        /// <returns></returns>
        public static int Delete(string tableName, string strWhere)
        {
            string sql = "Delete From " + tableName + strWhere;
            return DbHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 递归获取地区数据
        /// </summary>
        /// <param name="AreaCode"></param>
        /// <returns></returns>
        public static DataTable getAreaList(string AreaCode)
        {
            string sql = "with dictinfo as(select * from t_area where areacode = '" + AreaCode + "' union all select a.* from t_area a inner join dictinfo b on a.areacode= b.parentcode) select * from dictinfo ";
            return DbHelper.ExecuteDataset(sql).Tables[0];
        }
     

        /// <summary>
        /// 插入（返回插入ID或影响行数）
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <param name="key">主键/或自动增加字段（不进行SQL拼接）</param>
        /// <param name="returnKeyValue">返回插入ID</param>
        /// <returns></returns>
        public static int SaveInsert(DataRow dr, string key, bool returnID)
        {
            int id = 0;
            string sql = "";
            string cols = "";
            string vals = "";
            string colName = "";
            key = key.Trim();

            foreach (DataColumn col in dr.Table.Columns)
            {
                colName = col.ColumnName;

                if (colName == key.Trim() && returnID)
                {
                    continue;
                }

                if (dr[colName] != DBNull.Value)
                {
                    cols += "[" + colName + "],";
                    vals += "'" + dr[colName] + "',";
                }
            }

            if ((cols.Length > 0) && (vals.Length > 0) && (dr.Table.TableName.Length > 0))
            {
                cols = cols.Substring(0, cols.Length - 1);
                vals = vals.Substring(0, vals.Length - 1);
                sql = "Insert Into " + dr.Table.TableName + " (" + cols + ") Values (" + vals + ")";


                if (returnID)
                {
                    sql += ";select @@identity ";
                    id = Convert.ToInt32(DbHelper.ExecuteScalar(sql));
                }
                else
                {
                    id = Convert.ToInt32(DbHelper.ExecuteNonQuery(sql));
                }
            }

            return id;
        }

        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="dr">行数据</param>
        /// <param name="key">主键/或自动增加字段 (可能用于修改条件)</param>
        /// <param name="strWhere">Where='' 修改条件  为空时key=dr[key] 条件要加 and </param>
        /// <param name="returnID">=="key" 时返回dr[key]值</param>
        /// <returns>返回dr[key]值或影响行数</returns>
        public static int SaveUpdate(DataRow dr, string key, string strWhere, string returnID)
        {
            int result = 0;
            string vals = "";
            string colName = "";
            string tableName = dr.Table.TableName;

            //string where = "";

            foreach (DataColumn col in dr.Table.Columns)
            {
                colName = col.ColumnName;
                if (dr[colName] != DBNull.Value)
                {
                    if (colName.ToLower() == key.Trim().ToLower())
                    {
                        continue;
                    }
                    vals += "[" + colName + "]= '" + dr[colName] + "',";
                }
            }
            if ((vals.Length > 0) && (tableName.Length > 0))
            {
                vals = vals.Substring(0, vals.Length - 1);
                if (strWhere == "")
                    strWhere = key + "='" + dr[key].ToString() + "'";

                string sql = "Update " + tableName + " Set " + vals + strWhere;//And "+ key +" = '" + dr[key].ToString() + "'";

                ///返回影响行数
                result = DbHelper.ExecuteNonQuery(sql);
            }

            if (returnID.ToLower() == "key")
            {
                ///
                result = Convert.ToInt32(dr[key]);
            }

            return result;

        }


        /// <summary>
        /// 修改自定义字段数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">字段 ","</param>
        /// <param name="values">值 ","</param>
        /// <param name="strWhere">条件 where ''</param>
        /// <returns>影响行数</returns>
        public static int UpdateValue(string tableName, string fields, string values, string strWhere)
        {
            if (string.IsNullOrEmpty(fields) || values == null)
            {
                return 0;
            }
            else
            {
                string[] attField = Regex.Split(fields.EndsWith(",") ? fields.Substring(0, fields.Length - 1) : fields, Regex.Escape(","), RegexOptions.IgnoreCase);
                string[] attValue = Regex.Split(values.EndsWith(",") ? values.Substring(0, values.Length - 1) : values, Regex.Escape(","), RegexOptions.IgnoreCase);
                if (attField.Length < 0 || attValue.Length < 0)
                    return 0;
                StringBuilder sb = new StringBuilder();
                sb.Append(" update " + tableName);
                sb.Append(" set ");
                if (attField.Length == 1)
                {
                    sb.Append(fields + "='" + attValue[0] + "'");
                }
                else
                {
                    for (int i = 0; i < attField.Length; i++)
                    {
                        if (i == 0)
                        {
                            sb.Append(attField[i] + "='" + attValue[i] + "'");
                        }
                        else
                        {
                            sb.Append("," + attField[i] + "='" + attValue[i] + "'");
                        }
                    }
                }
                sb.Append(strWhere);
                return DbHelper.ExecuteNonQuery(sb.ToString());
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet BiYing(string pageindex)
        {
            string sql = "EXEC sp_TablePage " + pageindex + ",10,' and isshow=1','T_BiYing' ";

            return DbHelper.ExecuteDataset(sql);
        }
        #endregion

        #region 数据查询


        /// <summary>
        /// 获取DataRow 第一行数据
        /// </summary>
        /// <param name="tableName">表</param>
        /// <param name="field">字段</param>
        /// <param name="strWhere">条件 where ''</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static DataRow GetDataRow(string tableName, string field, string strWhere, string sort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (field != "")
                strSql.Append(field);
            else
                strSql.Append(" * ");
            strSql.Append(" from " + tableName + strWhere + sort);
            DataTable dt = DbHelper.ExecuteDataset(strSql.ToString()).Tables[0];

            if (dt.Rows.Count > 0)
            {
                dt.Rows[0].Table.TableName = tableName;
                return dt.Rows[0];
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr.Table.TableName = tableName;
                return dr;
            }


        }

        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="tableName">表</param>
        /// <param name="field">字段</param>
        /// <param name="strWhere">条件  where ''</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string tableName, string field, string strWhere, string sort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(field == "" ? " * " : field);
            strSql.Append(" from " + tableName + strWhere + sort);
            return DbHelper.ExecuteDataset(strSql.ToString());
        }

        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="tableName">表</param>
        /// <param name="field">字段</param>
        /// <param name="strWhere">条件  where ''</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string tableName, string field, string strWhere, string sort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(field == "" ? " * " : field);
            strSql.Append(" from " + tableName + strWhere + sort);
            return DbHelper.ExecuteDataset(strSql.ToString()).Tables[0];

        }
        /// <summary>
        /// 51团购
        /// </summary>
        /// <returns></returns>
        public static DataSet Brand51List()
        {
            string sql = "EXEC  sp_groupbuy ";
            return DbHelper.ExecuteDataset(sql);
        }

        /// <summary>
        /// 已确认订单 意向报名
        /// </summary>
        /// <param name="brandid"></param>
        /// <returns></returns>
        public static DataSet EnterUser(string brandid)
        {
            StringBuilder _sql = new StringBuilder(string.Empty);

            _sql.Append("SELECT COUNT(1) FROM OrderList WHERE total_fee>0 and ordernumber IN(");
            _sql.Append("SELECT ordernumber FROM OrderInfor WHERE productattributeId ");
            _sql.Append("IN( SELECT c.id FROM t_product p LEFT JOIN  t_productattribute c  ");
            _sql.Append("ON  p.id=c.productid WHERE p.brandid=" + brandid + " ))  ");

            _sql.Append(" SELECT COUNT(1) FROM OrderList WHERE total_fee IS NULL OR total_fee<=0 and ordernumber IN(");
            _sql.Append(" SELECT ordernumber FROM OrderInfor WHERE productattributeId IN( SELECT c.id FROM  ");
            _sql.Append(" t_product p LEFT JOIN  t_productattribute c ON  p.id=c.productid WHERE p.brandid=" + brandid + " )) ");

            return DbHelper.ExecuteDataset(_sql.ToString());

        }
        public static string CheckbuypriceName(string proid)
        {
            StringBuilder _sql = new StringBuilder("SELECT [dbo].[F_GetbuypriceName](" + proid + ") AS name ");
            return DbHelper.ExecuteDataset(_sql.ToString()).Tables[0].Rows[0][0].ToString();
        }
        /// <summary>
        /// 团购折数计算
        /// </summary>
        /// <param name="brandid"></param>
        /// <returns></returns>
        public static string getEnterSel(string brandid)
        {
            string sql = "EXEC sp_EnterUser " + brandid;
            DataSet ds = new DataSet();
            ds = DbHelper.ExecuteDataset(sql);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="strWhere">条件</param>
        /// <param name="key">主键</param>
        /// <param name="orderType">排序</param>
        /// <param name="pageCount">总数</param>
        /// <returns></returns>
        public static DataTable GetPageDataTable(string tableName, int PageIndex, int PageSize, string strWhere, string key, int orderType, out int pageCount)
        {
            if (string.IsNullOrEmpty(key))
            {
                key = "id";
            }
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = "1=1";
            }
            if (PageIndex == -1)
            {
                #region 不调用存储过程
                
                if (!string.IsNullOrEmpty(strWhere))
                    strWhere = " where " + strWhere;
                string strOrderBy = "";
                if (orderType == 1)
                {
                    strOrderBy = " order by " + key + " desc";
                }
                else
                {
                    strOrderBy = " order by " + key + " asc";
                }
                DataSet ds = new DataSet();
                if (PageSize > 0)
                {
                    ds = DbHelper.ExecuteDataset("select top " + PageSize + " * from " + tableName + strWhere + strOrderBy);
                }
                else
                {
                    ds = DbHelper.ExecuteDataset("select * from " + tableName + strWhere + strOrderBy);
                }
                if (ds.Tables.Count > 0)
                {
                    object obj = DbHelper.ExecuteScalar("select count(1) from " + tableName + strWhere);
                    pageCount = obj != null ? int.Parse(obj.ToString()) : 0;
                    return ds.Tables[0];
                }
                #endregion
            }
            else
            {
                SqlParameter[] parameters = {
                 new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                 new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                 new SqlParameter("@PageSize", SqlDbType.Int),
                 new SqlParameter("@PageIndex", SqlDbType.Int),
                 new SqlParameter("@IsReCount", SqlDbType.Bit),
                 new SqlParameter("@OrderType", SqlDbType.Bit),
                 new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                 new SqlParameter("@ReCount",SqlDbType.Int,4)
                };
                parameters[0].Value = tableName;
                parameters[1].Value = key;
                parameters[2].Value = PageSize;
                parameters[3].Value = PageIndex;
                parameters[4].Value = 1;
                parameters[5].Value = orderType;
                parameters[6].Value = strWhere;
                parameters[7].Direction = ParameterDirection.Output;
                parameters[7].Value = 0;

                DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
                pageCount = Convert.ToInt32(parameters[7].Value);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }

            DataTable dt = DbHelper.ExecuteDataset("select * from " + tableName + " where 1<>1").Tables[0];
            dt.TableName = tableName;
            pageCount = 0;
            return dt;
        }

        /// <summary>
        /// 获取DataReader
        /// </summary>
        /// <param name="tableName">表</param>
        /// <param name="field">字段</param>
        /// <param name="strWhere">条件  where ''</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static IDataReader GetDataIReader(string tableName, string field, string strWhere, string sort)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (field == "")
                strSql.Append(" * ");
            else
                strSql.Append(field);
            strSql.Append(" from " + tableName + strWhere + sort);
            IDataReader dr = DbHelper.ExecuteReader(strSql.ToString());
            return dr;
        }

        //        public static IDataReader GetPageDataReader(string tableName, string key,int pageIndex, int pageSize, string strWhere, string filed, string orderby, out int pageCount)
        //        {
        //            //降序
        //            string str = @" SELECT TOP {0} {2}
        //                             FROM {3}
        //                             WHERE {6} <=
        //                             (
        //                             SELECT ISNULL(MIN({6}),0) 
        //                             FROM 
        //                             (SELECT TOP ({0}*({1}-1)+1) {6} FROM {3} {7} order by {6}  desc) A ) {5}  {4}";
        //            //顺序
        //            string str2 = @" SELECT TOP {0} {2}
        //                             FROM {3}
        //                             WHERE {6} >=
        //                             (
        //                             SELECT ISNULL(max({6}),0) 
        //                             FROM 
        //                             (SELECT TOP ({0}*({1}-1)+1) {6} FROM {3} {7} order by {6}) A ) {5}  {4}";

        //            key = key != "" ? key : " id ";
        //            filed = filed != "" ? filed : " * ";
        //            orderby = orderby != "" ? orderby : " order by id";
        //            string ostrWhere = strWhere != "" ? " where 1=1 " + strWhere : "";


        //            object obj = DbHelper.ExecuteScalar("select count(1) from " + tableName + ostrWhere);
        //            if(obj!=null){pageCount=int.Parse(obj.ToString());}else{pageCount=0;}
        //            if (orderby != "" && (orderby.ToLower().Contains("asc") || (!orderby.ToLower().Contains("asc") && !orderby.ToLower().Contains("desc"))))
        //            {
        //                return DbHelper.ExecuteReader(string.Format(str2.ToString(), pageSize, pageIndex, filed, tableName, orderby, strWhere, key, ostrWhere));
        //            }
        //            else
        //            {
        //                return DbHelper.ExecuteReader(string.Format(str.ToString(), pageSize, pageIndex, filed, tableName, orderby, strWhere, key, ostrWhere));
        //            }
        //        }

        /// <summary>
        /// 单字段排序分页
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="sortkey">排序字段</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pagesSize">页大小</param>
        /// <param name="strWhere">条件</param>
        /// <param name="field">查询字段</param>
        /// <param name="orderByType">排序方式 0,顺序,1降顺</param>
        /// <param name="pageCount">总数</param>
        /// <returns></returns>
        public static IDataReader GetPageDataReader(string tableName, int pageIndex, int pagesSize, string strWhere, string field, string sortkey, string orderByType, out int pageCount)
        {
            sortkey = sortkey == "" ? "id" : sortkey;
            field = field == "" ? " * " : field;
            orderByType = orderByType == "0" || orderByType.Replace(" ", "").Trim() == "asc" ? " asc " : " desc ";
            string ostrWhere = strWhere == "" ? "" : " where 1=1 " + strWhere;
            string orderNull = sortkey != "id" ? ",id asc" : "";
            string orderNull2 = sortkey != "id" ? ",id desc" : "";

            //            string strAsc=@"SELECT TOP {2} {4} FROM {0} WHERE {5} >=
            // (SELECT ISNULL(max({5}),0) FROM (SELECT TOP ({2}*({1}-1)+1) {5} FROM {0} ORDER BY {5} {6} ) A) {3}  ORDER BY {5} {6}";

            //            string strDesc = @"SELECT TOP {2} {4} FROM {0} WHERE {5} <=
            // (SELECT ISNULL(MIN({5}),0) FROM (SELECT TOP ({2}*({1}-1)+1) {5} FROM {0} ORDER BY {5} Desc {6}) A) {3}  ORDER BY {5} Desc {6} ";


            //            pageCount = 0;
            //            object obj = DbHelper.ExecuteScalar("select count(1) from " + tableName + ostrWhere);
            //            if (obj != null) { pageCount = int.Parse(obj.ToString()); } else { pageCount = 0; }
            //            if (orderByType == "0" || orderByType.Contains("asc"))
            //            {
            //                return DbHelper.ExecuteReader(string.Format(strAsc.ToString(), tableName, pageIndex, pagesSize, strWhere, field, sortkey,orderNull));
            //            }
            //            else
            //            {
            //                return DbHelper.ExecuteReader(string.Format(strDesc.ToString(), tableName, pageIndex, pagesSize, strWhere, field, sortkey, orderNull2));
            //            }
            pageCount = 0;
            object obj = DbHelper.ExecuteScalar("select count(1) from " + tableName + ostrWhere);
            if (obj != null) { pageCount = int.Parse(obj.ToString()); } else { pageCount = 0; }
            string strSql = @"select {4} from 
(select row_number()over(order by {5} {6})rownumber,{4} from {0}  {3})a
where rownumber between ({2}*({1}-1)+1) and ({2}*{1})";
            return DbHelper.ExecuteReader(string.Format(strSql.ToString(), tableName, pageIndex, pagesSize, ostrWhere, field, sortkey, orderByType));

        }

        /// <summary>
        /// 单字段排序分页2
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pagesSize">页大小</param>
        /// <param name="strWhere">条件</param>
        /// <param name="field">查询字段</param>
        /// <param name="orderByType">排序方式 0,顺序,1降顺</param>
        /// <param name="pageCount">总数</param>
        public static IDataReader GetPageDataReader(string tableName, int pageIndex, int pageSize, string strWhere, string sortkey, string orderByType, out int pageCount)
        {
            return GetPageDataReader(tableName, pageIndex, pageSize, strWhere, "", sortkey, orderByType, out pageCount);
        }





        #endregion

        #region 结构

        /// <summary>
        /// 获取某表结构
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataRow GetTableStructure(string tableName)
        {
            //IDataReader read = DbHelper.ExecuteReader("select * from " + tableName + " where 1<>1");
            DataTable dt = DbHelper.ExecuteDataset("select * from " + tableName + " where 1<>1").Tables[0];
            dt.TableName = tableName;
            return dt.NewRow();
        }

        /// <summary>
        /// 判断是否存在某表的某个字段
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="columnName">列名称</param>
        /// <returns>是否存在</returns>
        public static bool ColumnExists(string tableName, string columnName)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = DbHelper.ExecuteScalar(sql.ToString());
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;
        }


        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool TabExists(string TableName)
        {
            string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
            object obj = DbHelper.ExecuteScalar(strsql.ToString());
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        #endregion

        //分类上移
        public static int CategoryNodeUp(string procedurename, int id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int)
                                        };
            parameters[0].Value = id;
            return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, procedurename, parameters);
        }        
    }
}
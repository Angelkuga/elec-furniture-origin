using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SQLDMO;

namespace TREC.Data
{
    public class SqlDataCommon
    {
        /// <summary>
        /// 备份数据库          
        /// </summary>
        /// <param name="backupPath">备份文件路径</param>
        /// <param name="serverName">服务器名称</param>
        /// <param name="userName">数据库用户名</param>
        /// <param name="password">数据库密码</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="fileName">备份文件名</param>
        /// <returns></returns>
        public string BackUpDatabase(string backUpPath, string serverName, string userName, string password, string strDbName, string strFileName)
        {
            SQLServer svr = new SQLServerClass();
            try
            {
                svr.Connect(serverName, userName, password);
                Backup bak = new BackupClass();
                bak.Action = 0;
                bak.Initialize = true;
                bak.Files = backUpPath + strFileName;
                bak.Database = strDbName;
                bak.SQLBackup(svr);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message.Replace("'", " ").Replace("\n", " ").Replace("\\", "/");
            }
            finally
            {
                svr.DisConnect();
            }
        }

        /// <summary>
        /// 恢复数据库          
        /// </summary>
        /// <param name="backupPath">备份文件路径</param>
        /// <param name="serverName">服务器名称</param>
        /// <param name="userName">数据库用户名</param>
        /// <param name="password">数据库密码</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="fileName">备份文件名</param>
        /// <returns></returns>
        public string RestoreDatabase(string backUpPath, string serverName, string userName, string password, string strDbName, string strFileName)
        {
            #region 数据库的恢复的代码

            SQLServer svr = new SQLServerClass();
            try
            {
                svr.Connect(serverName, userName, password);
                QueryResults qr = svr.EnumProcesses(-1);
                int iColPIDNum = -1;
                int iColDbName = -1;
                for (int i = 1; i <= qr.Columns; i++)
                {
                    string strName = qr.get_ColumnName(i);
                    if (strName.ToUpper().Trim() == "SPID")
                        iColPIDNum = i;
                    else if (strName.ToUpper().Trim() == "DBNAME")
                        iColDbName = i;

                    if (iColPIDNum != -1 && iColDbName != -1)
                        break;
                }

                for (int i = 1; i <= qr.Rows; i++)
                {
                    string strDBName = qr.GetColumnString(i, iColDbName);
                    if (strDBName.ToUpper() == strDbName.ToUpper())
                        svr.KillProcess(qr.GetColumnLong(i, iColPIDNum));
                }

                Restore res = new RestoreClass();
                res.Action = 0;
                res.Files = backUpPath + strFileName;
                res.Database = strDbName;
                res.ReplaceDatabase = true;
                res.SQLRestore(svr);
                return "";
            }
            catch (Exception err)
            {
                return err.Message.Replace("'", " ").Replace("\n", " ").Replace("\\", "/");
            }
            finally
            {
                svr.DisConnect();
            }
            #endregion
        }


        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string RunSql(string sql)
        {
            string errorInfo = "";
            if (sql != "")
            {
                SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
                conn.Open();
                string[] sqlArray = Tools.SplitString(sql, "--/* TR.Soft SQL Separator */--");
                
                foreach (string sqlStr in sqlArray)
                {
                    if (string.IsNullOrEmpty(sqlStr))   //当读到空的Sql语句则继续
                    {
                        continue;
                    }
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            DbHelper.ExecuteNonQuery(CommandType.Text, sqlStr);
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            string message = ex.Message.Replace("'", " ");
                            message = message.Replace("\\", "/");
                            message = message.Replace("\r\n", "\\r\\n");
                            message = message.Replace("\r", "\\r");
                            message = message.Replace("\n", "\\n");
                            errorInfo += message + "<br />";
                        }
                    }
                }
                conn.Close();
            }
            return errorInfo;
        }


        /// <summary>
        /// 执行SQLToDataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet RunSqlToDataSet(string sql,out string errorInfo)
        {
            DataSet ds = new DataSet();
            string message = "";
            if (sql != "")
            {
                SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
                conn.Open();
                string[] sqlArray = Tools.SplitString(sql, "--/* TR.Soft SQL Separator */--");
                foreach (string sqlStr in sqlArray)
                {
                    if (string.IsNullOrEmpty(sqlStr))   //当读到空的Sql语句则继续
                    {
                        continue;
                    }
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            ds = DbHelper.ExecuteDataset(CommandType.Text, sqlStr);
                            trans.Commit();
                            errorInfo = "";
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            message = ex.Message.Replace("'", " ");
                            message = message.Replace("\\", "/");
                            message = message.Replace("\r\n", "\\r\\n");
                            message = message.Replace("\r", "\\r");
                            message = message.Replace("\n", "\\n");
                            message += message + "<br />";
                        }
                    }
                }
                conn.Close();
                
            }
            errorInfo = message;
            return ds;
        }

        /// <summary>
        /// 查找所有数据库
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllDatabase(string connection,out string errorMsg)
        {
            string sql = "Select Name FROM Master.dbo.SysDatabases orDER BY Name";
            string errorInfo = "";
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connection);
                

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.Replace("'", " ");
                    message = message.Replace("\\", "/");
                    message = message.Replace("\r\n", "\\r\\n");
                    message = message.Replace("\r", "\\r");
                    message = message.Replace("\n", "\\n");
                    errorInfo += message + "<br />";
                }

                if (string.IsNullOrEmpty(errorInfo))
                {
                    string[] sqlArray = Tools.SplitString(sql, "--/* TR.Soft SQL Separator */--");

                    foreach (string sqlStr in sqlArray)
                    {
                        if (string.IsNullOrEmpty(sqlStr))   //当读到空的Sql语句则继续
                        {
                            continue;
                        }
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            try
                            {
                                ds = DbHelper.ExecuteDataset(CommandType.Text, sqlStr);
                                trans.Commit();
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                string message = ex.Message.Replace("'", " ");
                                message = message.Replace("\\", "/");
                                message = message.Replace("\r\n", "\\r\\n");
                                message = message.Replace("\r", "\\r");
                                message = message.Replace("\n", "\\n");
                                errorInfo += message + "<br />";

                            }
                        }
                    }
                    conn.Close();
                }
                errorMsg = errorInfo;
                return ds;
        }

        /// <summary>
        /// 查找所有数据库
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllTable(string connection, string database, out string errorMsg)
        {
            string sql = "use " + database + "  SELECT name FROM sysobjects WHERE type = 'U'";
            string errorInfo = "";
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connection + "database=" + database + ";");
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                conn.Close();
                string message = ex.Message.Replace("'", " ");
                message = message.Replace("\\", "/");
                message = message.Replace("\r\n", "\\r\\n");
                message = message.Replace("\r", "\\r");
                message = message.Replace("\n", "\\n");
                errorInfo += message + "<br />";
            }
            if (string.IsNullOrEmpty(errorInfo))
            {

                string[] sqlArray = Tools.SplitString(sql, "--/* TR.Soft SQL Separator */--");

                foreach (string sqlStr in sqlArray)
                {
                    if (string.IsNullOrEmpty(sqlStr))   //当读到空的Sql语句则继续
                    {
                        continue;
                    }
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            ds = DbHelper.ExecuteDataset(CommandType.Text, sqlStr);
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            string message = ex.Message.Replace("'", " ");
                            message = message.Replace("\\", "/");
                            message = message.Replace("\r\n", "\\r\\n");
                            message = message.Replace("\r", "\\r");
                            message = message.Replace("\n", "\\n");
                            errorInfo += message + "<br />";
                        }
                    }
                }

                conn.Close();
            }
            errorMsg = errorInfo;
            return ds;
        }

        /// <summary>
        /// 获取所有列
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DataSet GetAllFields(string connection,string dbname, string tableName, out string errorMsg)
        {
            StringBuilder sb=new StringBuilder();
            DataSet ds = new DataSet();
            string errorInfo = "";
            sb.Append("use " + dbname + "   ");
            sb.Append(@" SELECT
                        tableName=case when a.colorder=1 then d.name else '' end,
                        tableDescript=case when a.colorder=1 then isnull(f.value,'') else '' end,
                        fieldId=a.colorder,
                        fieldName=a.name,
                        fieldMark=case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end,
                        fieldPK=case when exists(SELECT 1 FROM sysobjects where xtype='PK' and name in (
                        SELECT name FROM sysindexes WHERE indid in(
                        SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid
                        ))) then '√' else '' end,
                        fieldType=b.name,
                        fieldByte=a.length,
                        fieldLength=COLUMNPROPERTY(a.id,a.name,'PRECISION'),
                        fieldScale=isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),
                        fieldNull=case when a.isnullable=1 then '√'else '' end,
                        fieldDefaultValue=isnull(e.text,''),
                        fieldDescript=isnull(g.[value],'')
                        FROM syscolumns a
                        left join systypes b on a.xusertype=b.xusertype
                        inner join sysobjects d on a.id=d.id and d.xtype='U' and d.name<>'dtproperties'
                        left join syscomments e on a.cdefault=e.id
                        left join sys.extended_properties g on a.id=g.major_id and a.colid=g.minor_id
                        left join sys.extended_properties f on d.id=f.major_id and f.minor_id=0");
                        if(!string.IsNullOrEmpty(tableName))
                            sb.Append("where d.name='"+tableName+"' --如果只查询指定表,加上此条件");
                        sb.Append(" order by a.id,a.colorder");

            SqlConnection conn = new SqlConnection(connection);
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    ds = DbHelper.ExecuteDataset(CommandType.Text, sb.ToString());
                    trans.Commit();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                conn.Close();
                string message = ex.Message.Replace("'", " ");
                message = message.Replace("\\", "/");
                message = message.Replace("\r\n", "\\r\\n");
                message = message.Replace("\r", "\\r");
                message = message.Replace("\n", "\\n");
                errorInfo += message + "<br />";
            }
            conn.Close();
            errorMsg = errorInfo;
            return ds;
        }

    }
}

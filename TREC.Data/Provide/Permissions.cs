using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TREC.Entity;
using TRECommon;


namespace TREC.Data
{
    public class Permissions
    {

        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditModule(EnModule model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_sys_module(");
                strSql.Append("title,mark,type,descript,sort)");
                strSql.Append(" values (");
                strSql.Append("@title,@mark,@type,@descript,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@mark", SqlDbType.VarChar,20),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.mark;
                parameters[2].Value = model.type;
                parameters[3].Value = model.descript;
                parameters[4].Value = model.sort;

                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_sys_module set ");
                strSql.Append("title=@title,");
                strSql.Append("mark=@mark,");
                strSql.Append("descript=@descript,");
                strSql.Append("sort=@sort,");
                strSql.Append("type=@type");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@mark", SqlDbType.VarChar,20),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.mark;
                parameters[2].Value = model.descript;
                parameters[3].Value = model.sort;
                parameters[4].Value = model.type;
                parameters[5].Value = model.id;

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
        public static EnModule GetModuleInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from t_sys_module ");
            strSql.Append(strWhere);
            

            EnModule model = new EnModule();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["mark"] != null && reader["mark"].ToString() != "")
                {
                    model.mark = reader["mark"].ToString();
                }
                if (reader["type"] != null && reader["type"].ToString() != "")
                {
                    model.type = reader["type"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
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
        public static List<EnModule> GetModuleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnModule> modelList = new List<EnModule>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBSystemModule, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            
            if (dt.Rows.Count > 0)
            {
                EnModule model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnModule();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["mark"] != null && dt.Rows[n]["mark"].ToString() != "")
                    {
                        model.mark = dt.Rows[n]["mark"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = dt.Rows[n]["type"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        #region 共公模块连接

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditModuleLink(EnModuleLink model)
        {
            DbHelper.ExecuteNonQuery(CommandType.Text, " delete from t_sys_module where mid=" + model.ModuleId);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_sys_module_link(");
            strSql.Append("mid,title,icourl,linkurl)");
            strSql.Append(" values (");
            strSql.Append("@mid,@title,@icourl,@linkurl)");
            SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@icourl", SqlDbType.VarChar,40),
					new SqlParameter("@linkurl", SqlDbType.VarChar,40)};
            parameters[0].Value = model.ModuleId;
            parameters[1].Value = model.title;
            parameters[2].Value = model.icourl;
            parameters[3].Value = model.linkurl;

                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
           

            return 0;

        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnModuleLink> GetModuleLinkList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnModuleLink> modelList = new List<EnModuleLink>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBSystemModuleLink, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnModuleLink model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnModuleLink();
                    if (dt.Rows[n]["mid"] != null && dt.Rows[n]["mid"].ToString() != "")
                    {
                        model.ModuleId = int.Parse(dt.Rows[n]["mid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["icourl"] != null && dt.Rows[n]["icourl"].ToString() != "")
                    {
                        model.icourl = dt.Rows[n]["icourl"].ToString();
                    }
                    if (dt.Rows[n]["linkurl"] != null && dt.Rows[n]["linkurl"].ToString() != "")
                    {
                        model.linkurl = dt.Rows[n]["linkurl"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        #region 共公动作

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAction(EnAction model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_sys_action(");
                strSql.Append("title,mark,mid,actype,descript,sort)");
                strSql.Append(" values (");
                strSql.Append("@title,@mark,@mid,@actype,@descript,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@mark", SqlDbType.VarChar,30),
					new SqlParameter("@mid", SqlDbType.Int,4),
					new SqlParameter("@actype", SqlDbType.Int,4),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.mark;
                parameters[2].Value = model.mid;
                parameters[3].Value = model.actype;
                parameters[4].Value = model.descript;
                parameters[5].Value = model.sort;

                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_sys_action set ");
                strSql.Append("title=@title,");
                strSql.Append("mark=@mark,");
                strSql.Append("mid=@mid,");
                strSql.Append("actype=@actype,");
                strSql.Append("descript=@descript,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@mark", SqlDbType.VarChar,30),
					new SqlParameter("@mid", SqlDbType.Int,4),
					new SqlParameter("@actype", SqlDbType.Int,4),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.mark;
                parameters[2].Value = model.mid;
                parameters[3].Value = model.actype;
                parameters[4].Value = model.descript;
                parameters[5].Value = model.sort;
                parameters[6].Value = model.id;

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
        public static EnAction GetActionInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + TableName.TBSystemAction + " ");
            strSql.Append(strWhere);


            EnAction model = new EnAction();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["mark"] != null && reader["mark"].ToString() != "")
                {
                    model.mark = reader["mark"].ToString();
                }
                if (reader["mid"] != null && reader["mid"].ToString() != "")
                {
                    model.mid = int.Parse(reader["mid"].ToString());
                }
                if (reader["actype"] != null && reader["actype"].ToString() != "")
                {
                    model.actype = int.Parse(reader["actype"].ToString());
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
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
        public static List<EnAction> GetActionList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAction> modelList = new List<EnAction>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBSystemAction, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnAction model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnAction();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["mark"] != null && dt.Rows[n]["mark"].ToString() != "")
                    {
                        model.mark = dt.Rows[n]["mark"].ToString();
                    }
                    if (dt.Rows[n]["mid"] != null && dt.Rows[n]["mid"].ToString() != "")
                    {
                        model.mid = int.Parse(dt.Rows[n]["mid"].ToString());
                    }
                    if (dt.Rows[n]["actype"] != null && dt.Rows[n]["actype"].ToString() != "")
                    {
                        model.actype = int.Parse(dt.Rows[n]["actype"].ToString());
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        #region 共公角色

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditRole(EnRole model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_sys_role(");
                strSql.Append("parentid,title,mark,descript,sort)");
                strSql.Append(" values (");
                strSql.Append("@parentid,@title,@mark,@descript,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@mark", SqlDbType.VarChar,20),
					new SqlParameter("@descript", SqlDbType.NVarChar,200),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.parentid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.mark;
                parameters[3].Value = model.descript;
                parameters[4].Value = model.sort;

                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_sys_role set ");
                strSql.Append("parentid=@parentid,");
                strSql.Append("title=@title,");
                strSql.Append("mark=@mark,");
                strSql.Append("descript=@descript,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@mark", SqlDbType.VarChar,20),
					new SqlParameter("@descript", SqlDbType.NVarChar,200),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.parentid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.mark;
                parameters[3].Value = model.descript;
                parameters[4].Value = model.sort;
                parameters[5].Value = model.id;

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
        public static EnRole GetRoleInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + TableName.TBSystemRole + " ");
            strSql.Append(strWhere);


            EnRole model = new EnRole();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["parentid"] != null && reader["parentid"].ToString() != "")
                {
                    model.parentid = int.Parse(reader["parentid"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["mark"] != null && reader["mark"].ToString() != "")
                {
                    model.mark = reader["mark"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
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
        public static List<EnRole> GetRoleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnRole> modelList = new List<EnRole>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBSystemRole, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnRole model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnRole();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["parentid"] != null && dt.Rows[n]["parentid"].ToString() != "")
                    {
                        model.parentid = int.Parse(dt.Rows[n]["parentid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["mark"] != null && dt.Rows[n]["mark"].ToString() != "")
                    {
                        model.mark = dt.Rows[n]["mark"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        #region 共公角色动作关联信息

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditRoleActionDef(EnRoleActionDef model)
        {
            StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_sys_roleactiondef(");
			strSql.Append("actionid,moduleid,roleid)");
			strSql.Append(" values (");
			strSql.Append("@actionid,@moduleid,@roleid)");
			SqlParameter[] parameters = {
					new SqlParameter("@actionid", SqlDbType.Int,4),
					new SqlParameter("@moduleid", SqlDbType.Int,4),
					new SqlParameter("@roleid", SqlDbType.Int,4)};
			parameters[0].Value = model.actionid;
			parameters[1].Value = model.moduleid;
			parameters[2].Value = model.roleid;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj != null)
            {
                return TypeConverter.ObjectToInt(obj);
            }
           
            return 0;

        }

        public static List<EnRoleActionDef> GetRoleActionDefList(string strWhere)
        {
            List<EnRoleActionDef> modelList = new List<EnRoleActionDef>();
            DataTable dt = DataCommon.GetDataTable(TableName.TBRoleActionDef, "", strWhere, "");

            if (dt.Rows.Count > 0)
            {
                EnRoleActionDef model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnRoleActionDef();
                    if (dt.Rows[n]["actionid"] != null && dt.Rows[n]["actionid"].ToString() != "")
                    {
                        model.actionid = int.Parse(dt.Rows[n]["actionid"].ToString());
                    }
                    if (dt.Rows[n]["moduleid"] != null && dt.Rows[n]["moduleid"].ToString() != "")
                    {
                        model.moduleid = int.Parse(dt.Rows[n]["moduleid"].ToString());
                    }
                    if (dt.Rows[n]["roleid"] != null && dt.Rows[n]["roleid"].ToString() != "")
                    {
                        model.roleid = int.Parse(dt.Rows[n]["roleid"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion

    }
}

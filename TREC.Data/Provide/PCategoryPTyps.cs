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
    public class PCategoryPTyps
    {

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditPCategoryPTyp(List<EnPCategoryPTyp> list)
        {

            if (list != null && list.Count > 0)
            {
                DbHelper.ExecuteNonQuery(" delete from t_pcategoryptypedef where productcategoryid=" + list[0].productcategoryid);


                List<CommandInfo> l = new List<CommandInfo>();
                foreach (EnPCategoryPTyp model in list)
                {
                    CommandInfo c = new CommandInfo();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into t_pcategoryptypedef(");
                    strSql.Append("productcategoryid,producttypeid)");
                    strSql.Append(" values (");
                    strSql.Append("@productcategoryid,@producttypeid)");
                    SqlParameter[] parameters = {
					new SqlParameter("@productcategoryid", SqlDbType.Int,4),
					new SqlParameter("@producttypeid", SqlDbType.Int,4)};
                    parameters[0].Value = model.productcategoryid;
                    parameters[1].Value = model.producttypeid;

                    c.EffentNextType = EffentNextType.ExcuteEffectRows;
                    c.CommandText = strSql.ToString();
                    c.Parameters = parameters;
                    l.Add(c);

                }

                return DbHelper.ExecuteSqlTran(l);
            }
            return 0;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnPCategoryPTyp> GetPCategoryPTypList(string fields,string strWhere)
        {
            List<EnPCategoryPTyp> modelList = new List<EnPCategoryPTyp>();
            DataTable dt = DataCommon.GetDataTable(TableName.TBPCategoryPTyp, fields, strWhere, "");
            if (dt.Rows.Count > 0)
            {
                EnPCategoryPTyp model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnPCategoryPTyp();
                    if (dt.Rows[n]["productcategoryid"] != null && dt.Rows[n]["productcategoryid"].ToString() != "")
                    {
                        model.productcategoryid = int.Parse(dt.Rows[n]["productcategoryid"].ToString());
                    }
                    if (dt.Rows[n]["producttypeid"] != null && dt.Rows[n]["producttypeid"].ToString() != "")
                    {
                        model.producttypeid = int.Parse(dt.Rows[n]["producttypeid"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

    }
}

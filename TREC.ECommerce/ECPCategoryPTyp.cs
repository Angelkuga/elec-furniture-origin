using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TREC.Entity;
using TREC.Data;
using TRECommon;


namespace TREC.ECommerce
{
    public class ECPCategoryPTyp
    {

        #region  Method-PCategoryPTyp
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditPCategoryPTyp(List<EnPCategoryPTyp> list)
        {
            return PCategoryPTyps.EditPCategoryPTyp(list);
        }

        public static string GetProductCategoryTypeValueList(int productcategoryid)
        {

            List<EnPCategoryPTyp> list = ECPCategoryPTyp.GetPCategoryPTypList("", " where productcategoryid=" + productcategoryid);
            string idlist = "";
            foreach (EnPCategoryPTyp e in list)
            {
                idlist += e.producttypeid + ",";
            }
            return idlist.Length > 0 && idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist == "" ? "0" : idlist;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnPCategoryPTyp> GetPCategoryPTypList(string fields, string strWhere)
        {
            return PCategoryPTyps.GetPCategoryPTypList(fields, strWhere);
        }


        //获取数据列表ToDataTable
        public static DataTable GetPCategoryPTypListToTable(string fields,string strWhere)
        {
            return DataCommon.GetDataTable(TableName.TBPCategoryPTyp, fields, strWhere, "");
        }

        ///删除对象
        public static int DeletePCategoryPTypByProductCategoryId(int productcategoryid)
        {
            return DeletePCategoryPTyp(" where productcategoryid=" + productcategoryid);
        }
        ///删除对象
        public static int DeletePCategoryPTypByProductCategoryIdList(string idList)
        {
            return DeletePCategoryPTyp(" where productcategoryid in (" + idList + ")");
        }
        ///删除对象
        public static int DeletePCategoryPTyp(string strWhere)
        {
            return DataCommon.Delete(TableName.TBPCategoryPTyp, strWhere);
        }
        #endregion
    }
}

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
    public class ECAction
    {
        #region  Method-Action
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAction(EnAction model)
        {
            return Permissions.EditAction(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnAction GetActionInfo(string strWhere)
        {
            return Permissions.GetActionInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnAction> GetActionList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Permissions.GetActionList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAction> GetActionList(string strWhere, out int pageCount)
        {
            return GetActionList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAction> GetActionList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetActionList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetActionListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBSystemAction, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnAction(int id)
        {
            return DeletEnAction(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnActionByIdList(string idList)
        {
            return DeletEnAction(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnAction(string strWhere)
        {
            return DataCommon.Delete(TableName.TBSystemAction, strWhere);
        }
        #endregion
    }
}

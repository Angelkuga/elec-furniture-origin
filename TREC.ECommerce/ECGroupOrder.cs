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
    public class ECGroupOrder
    {
        #region  Method-GroupOrder
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditGroupOrder(EnGroupOrder model)
        {
            return GroupOrders.EditGroupOrder(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnGroupOrder GetGroupOrderInfo(string strWhere)
        {
            return GroupOrders.GetGroupOrderInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnGroupOrder> GetGroupOrderList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return GroupOrders.GetGroupOrderList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnGroupOrder> GetGroupOrderList(string strWhere, out int pageCount)
        {
            return GetGroupOrderList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnGroupOrder> GetGroupOrderList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetGroupOrderList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetGroupOrderListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBGroupOrder, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteGroupOrder(int id)
        {
            return DeleteGroupOrder(" where id=" + id);
        }
        ///删除对象
        public static int DeleteGroupOrderByIdList(string idList)
        {
            return DeleteGroupOrder(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteGroupOrder(string strWhere)
        {
            return DataCommon.Delete(TableName.TBGroupOrder, strWhere);
        }
        #endregion
    }
}

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
    public class ECGroupOrderPay
    {
        #region  Method-GroupOrderPay
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditGroupOrderPay(EnGroupOrderPay model)
        {
            return GroupOrders.EditGroupOrderPay(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnGroupOrderPay GetGroupOrderPayInfo(string strWhere)
        {
            return GroupOrders.GetGroupOrderPayInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnGroupOrderPay> GetGroupOrderPayList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return GroupOrders.GetGroupOrderPayList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnGroupOrderPay> GetGroupOrderPayList(string strWhere, out int pageCount)
        {
            return GetGroupOrderPayList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnGroupOrderPay> GetGroupOrderPayList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetGroupOrderPayList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetGroupOrderPayListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBGroupOrderPay, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteGroupOrderPay(int id)
        {
            return DeleteGroupOrderPay(" where id=" + id);
        }
        ///删除对象
        public static int DeleteGroupOrderPayByIdList(string idList)
        {
            return DeleteGroupOrderPay(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteGroupOrderPay(string strWhere)
        {
            return DataCommon.Delete(TableName.TBGroupOrderPay, strWhere);
        }
        #endregion
    }
}

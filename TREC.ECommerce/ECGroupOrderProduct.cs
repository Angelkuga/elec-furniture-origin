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
    public class ECGroupOrderProduct
    {
        #region  Method-GroupOrderProduct
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditGroupOrderProduct(EnGroupOrderProduct model)
        {
            return GroupOrders.EditGroupOrderProduct(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnGroupOrderProduct GetGroupOrderProductInfo(string strWhere)
        {
            return GroupOrders.GetGroupOrderProductInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnGroupOrderProduct> GetGroupOrderProductList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return GroupOrders.GetGroupOrderProductList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnGroupOrderProduct> GetGroupOrderProductList(string strWhere, out int pageCount)
        {
            return GetGroupOrderProductList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnGroupOrderProduct> GetGroupOrderProductList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetGroupOrderProductList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetGroupOrderProductListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBGroupOrderProduct, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteGroupOrderProduct(int id)
        {
            return DeleteGroupOrderProduct(" where id=" + id);
        }
        ///删除对象
        public static int DeleteGroupOrderProductByIdList(string idList)
        {
            return DeleteGroupOrderProduct(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteGroupOrderProduct(string strWhere)
        {
            return DataCommon.Delete(TableName.TBGroupOrderProduct, strWhere);
        }
        #endregion
    }
}

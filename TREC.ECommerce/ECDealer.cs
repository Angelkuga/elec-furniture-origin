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
    public class ECDealer
    {


        public static int ExitDealer(string title)
        {
            return Dealers.ExitDealer(title);
        }


        public static int UpConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBDealer, "descript", con, " where id=" + id);
        }

        #region  Method-Dealer
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditDealer(EnDealer model)
        {
            return Dealers.EditDealer(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnDealer GetDealerInfo(string strWhere)
        {
            return Dealers.GetDealerInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnDealer> GetDealerList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Dealers.GetDealerList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnDealer> GetDealerList(string strWhere, out int pageCount)
        {
            return GetDealerList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnDealer> GetDealerList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetDealerList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetDealerListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBDealer, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteDealer(int id)
        {
            return DeleteDealer(" where id=" + id);
        }
        ///删除对象
        public static int DeleteDealerByIdList(string idList)
        {
            return DeleteDealer(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteDealer(string strWhere)
        {
            return DataCommon.Delete(TableName.TBDealer, strWhere);
        }
        #endregion

        #region  Method-DealerGroup
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditDealerGroup(EnDealerGroup model)
        {
            return Dealers.EditDealerGroup(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnDealerGroup GetDealerGroupInfo(string strWhere)
        {
            return Dealers.GetDealerGroupInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnDealerGroup> GetDealerGroupList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Dealers.GetDealerGroupList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnDealerGroup> GetDealerGroupList(string strWhere, out int pageCount)
        {
            return GetDealerGroupList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnDealerGroup> GetDealerGroupList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetDealerGroupList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetDealerGroupListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBDealerGroup, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnDealerGroup(int id)
        {
            return DeletEnDealerGroup(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnDealerGroupByIdList(string idList)
        {
            return DeletEnDealerGroup(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnDealerGroup(string strWhere)
        {
            return DataCommon.Delete(TableName.TBDealerGroup, strWhere);
        }
        #endregion

        #region 后台列表查询
        /// <summary>
        /// 后台Dealer列表查询
        /// </summary>
        public static List<EnDealer> GetAdminDealerList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Dealers.GetAdminDealerList(PageIndex, PageSize, strWhere, out pageCount);
        }
        #endregion
    }
}

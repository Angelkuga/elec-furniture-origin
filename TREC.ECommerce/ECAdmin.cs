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
    public class ECAdmin
    {
        #region  Method-Admin
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAdmin(EnAdmin model)
        {
            return Administrators.EditAdmin(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnAdmin GetAdminInfo(string strWhere)
        {
            return Administrators.GetAdminInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnAdmin> GetAdminList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Administrators.GetAdminList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAdmin> GetAdminList(string strWhere, out int pageCount)
        {
            return GetAdminList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAdmin> GetAdminList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetAdminList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetAdminListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBAdmin, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnAdmin(int id)
        {
            return DeletEnAdmin(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnAdminByIdList(string idList)
        {
            return DeletEnAdmin(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnAdmin(string strWhere)
        {
            return DataCommon.Delete(TableName.TBAdmin, strWhere);
        }
        #endregion
    }
}

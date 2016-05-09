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
    public class ECModuleLink
    {
		#region  Method-ModuleLink
		/// <summary>
        /// 更新对像
        /// </summary>
        public static int EditModuleLink(EnModuleLink model)
        {
            return Permissions.EditModuleLink(model);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnModuleLink> GetModuleLinkList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Permissions.GetModuleLinkList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnModuleLink> GetModuleLinkList(string strWhere, out int pageCount)
        {
            return GetModuleLinkList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnModuleLink> GetModuleLinkList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetModuleLinkList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetModuleLinkListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBSystemModuleLink, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnModuleLink(int id)
        {
            return DeletEnModuleLink(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnModuleLinkByIdList(string idList)
        {
            return DeletEnModuleLink(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnModuleLink(string strWhere)
        {
            return DataCommon.Delete(TableName.TBSystemModuleLink, strWhere);
        }
		#endregion
    }
}

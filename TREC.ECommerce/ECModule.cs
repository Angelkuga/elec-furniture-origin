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
    public class ECModule
    {
        #region 共公

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditModule(EnModule model)
        {
            return Permissions.EditModule(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnModule GetModuleInfo(string strWhere)
        {
            return Permissions.GetModuleInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnModule> GetModuleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Permissions.GetModuleList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnModule> GetModuleList(string strWhere, out int pageCount)
        {
            return GetModuleList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnModule> GetModuleList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetModuleList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetModuleListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBSystemModule, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteModule(int id)
        {
            return DeleteModule(" where id=" + id);
        }
        ///删除对象
        public static int DeleteModuleByIdList(string idList)
        {
            return DeleteModule(" where id in (" + idList + ")");
        }

        public static int UpModuleSort(int id, string sort)
        {
            return DataCommon.UpdateValue(TableName.TBSystemModule, "sort", sort, " where id=" + id);
        }

        ///删除对象
        public static int DeleteModule(string strWhere)
        {
            return DataCommon.Delete(TableName.TBSystemModule, strWhere);
        }

        #endregion
    }

    public class EnModuleDescSort : IComparer<EnModule>
    {
        public int Compare(EnModule x, EnModule y)
        {
            return y.sort.CompareTo(x.sort);
        }
    } 
}

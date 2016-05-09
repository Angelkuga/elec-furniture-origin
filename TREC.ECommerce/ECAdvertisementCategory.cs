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
    public class ECAdvertisementCategory
    {
        #region  Method-AdvertisementCategory

        public static int ExitAdvertisementCategory(int id)
        {
            return DataCommon.Exists(TableName.TBAdvertisementCategory, " where id=" + id);
        }

        public static string GetAdCategropyAdType(string id)
        {
            return DataCommon.GetDataRow(TableName.TBAdvertisementCategory, "adtype", " where id=" + id, "")["adtype"].ToString();
        }


        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAdvertisementCategory(EnAdvertisementCategory model)
        {
            return Advertisements.EditAdvertisementCategory(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnAdvertisementCategory GetAdvertisementCategoryInfo(string strWhere)
        {
            return Advertisements.GetAdvertisementCategoryInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnAdvertisementCategory> GetAdvertisementCategoryList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Advertisements.GetAdvertisementCategoryList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAdvertisementCategory> GetAdvertisementCategoryList(string strWhere, out int pageCount)
        {
            return GetAdvertisementCategoryList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAdvertisementCategory> GetAdvertisementCategoryList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetAdvertisementCategoryList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetAdvertisementCategoryListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBAdvertisementCategory, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnAdvertisementCategory(int id)
        {
            return DeletEnAdvertisementCategory(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnAdvertisementCategoryByIdList(string idList)
        {
            return DeletEnAdvertisementCategory(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnAdvertisementCategory(string strWhere)
        {
            return DataCommon.Delete(TableName.TBAdvertisementCategory, strWhere);
        }
        #endregion
    }
}

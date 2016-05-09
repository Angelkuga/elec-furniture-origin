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
    public class ECAppBrand
    {
        #region  Method-AppBrand

        public static int AddAppendBrand(List<EnAppBrand> list)
        {
            return Brands.AddAppendBrand(list);
        }

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAppBrand(EnAppBrand model)
        {
            return Brands.EditAppBrand(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnAppBrand GetAppBrandInfo(string strWhere)
        {
            return Brands.GetAppBrandInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnAppBrand> GetAppBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Brands.GetAppBrandList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAppBrand> GetAppBrandList(string strWhere, out int pageCount)
        {
            return GetAppBrandList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAppBrand> GetAppBrandList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetAppBrandList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetAppBrandListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBAppBrand, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }


        public static string GetAppBrandIdListByCompany(string companyId)
        {
            List<EnAppBrand> list = GetAppBrandList(" companyid=" + companyId);
            StringBuilder sb = new StringBuilder();
            foreach (EnAppBrand b in list)
            {
                sb.Append(b.id + ",");
            }

            return sb.ToString().Length > 0 && sb.ToString().EndsWith(",") ? sb.ToString().Substring(0, sb.ToString().Length - 1) : sb.ToString();

        }


        ///删除对象
        public static int UpAppBrand(int id)
        {
            return DataCommon.UpdateValue(TableName.TBAppBrand, "auditstatus", "1", " where id=" + id);
        }

        ///删除对象
        public static int DeleteAppBrand(int id)
        {
            return DeleteAppBrand(" where id=" + id);
        }
        ///删除对象
        public static int DeleteAppBrandByIdList(string idList)
        {
            return DeleteAppBrand(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteAppBrand(string strWhere)
        {
            return DataCommon.Delete(TableName.TBAppBrand, strWhere);
        }
        #endregion
    }
}

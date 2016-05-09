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
    public class ECAppPromotion
    {
        #region  Method-PromotionAppBrand


        public static int UpConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBPromotionAppBrand, "descript", con, " where id=" + id);
        }


        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditPromotionAppBrand(EnPromotionAppBrand model)
        {
            return AppPromotions.EditPromotionAppBrand(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnPromotionAppBrand GetPromotionAppBrandInfo(string strWhere)
        {
            return AppPromotions.GetPromotionAppBrandInfo(strWhere);
        }

        public static List<EnPromotionAppBrand> GetPromotionAppBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return GetPromotionAppBrandList(PageIndex, PageSize, strWhere, "", out pageCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnPromotionAppBrand> GetPromotionAppBrandList(int PageIndex, int PageSize, string strWhere, string orderby, out int pageCount)
        {
            return AppPromotions.GetPromotionAppBrandList(PageIndex, PageSize, strWhere, orderby, out pageCount);
        }

        ///获取数据列表
        public static List<EnPromotionAppBrand> GetPromotionAppBrandList(string strWhere, out int pageCount)
        {
            return GetPromotionAppBrandList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnPromotionAppBrand> GetPromotionAppBrandList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetPromotionAppBrandList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetPromotionAppBrandListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBPromotionAppBrand, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }


        public static string GetPromotionAppBrandIdListByCompany(string companyId)
        {
            List<EnPromotionAppBrand> list = GetPromotionAppBrandList(" companyid=" + companyId);
            StringBuilder sb = new StringBuilder();
            foreach (EnPromotionAppBrand b in list)
            {
                sb.Append(b.id + ",");
            }

            return sb.ToString().Length > 0 && sb.ToString().EndsWith(",") ? sb.ToString().Substring(0, sb.ToString().Length - 1) : sb.ToString();

        }


        ///删除对象
        public static int UpPromotionAppBrand(int id)
        {
            return DataCommon.UpdateValue(TableName.TBPromotionAppBrand, "auditstatus", "1", " where id=" + id);
        }

        ///删除对象
        public static int DeletePromotionAppBrand(int id)
        {
            return DeletePromotionAppBrand(" where id=" + id);
        }
        ///删除对象
        public static int DeletePromotionAppBrandByIdList(string idList)
        {
            return DeletePromotionAppBrand(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletePromotionAppBrand(string strWhere)
        {
            return DataCommon.Delete(TableName.TBPromotionAppBrand, strWhere);
        }
        #endregion

        #region  Method-AppBrandCustomer

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAppBrandCustomer(EnAppBrandCustomer model)
        {
            return AppPromotions.EditAppBrandCustomer(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnAppBrandCustomer GetAppBrandCustomerInfo(string strWhere)
        {
            return AppPromotions.GetAppBrandCustomerInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnAppBrandCustomer> GetAppBrandCustomerList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return AppPromotions.GetAppBrandCustomerList(PageIndex, PageSize, strWhere, out pageCount);
        }

        public static List<EnAppProduct> GetAppProductList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return AppPromotions.GetAppBrandProductList(PageIndex, PageSize, strWhere, out pageCount);
        }

        public static DataTable GetAppProductListUsers()
        {
            return DataCommon.GetDataTable(TableName.TBAppBrandProduct, "mid,name", " group by mid,name", "");
        }

        public static DataTable GetAppCustomerListUsers()
        {
            return DataCommon.GetDataTable(TableName.TBAppBrandCustomer, "name", " group by name", "");
        }
        public static DataTable GetAppCustomerListAreas()
        {
            return DataCommon.GetDataTable(TableName.TBAppBrandCustomer, "address", " where address<>'' and address is not null  group by address", "");
        }

        ///获取数据列表
        public static List<EnAppBrandCustomer> GetAppBrandCustomerList(string strWhere, out int pageCount)
        {
            return GetAppBrandCustomerList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAppBrandCustomer> GetAppBrandCustomerList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetAppBrandCustomerList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetAppBrandCustomerListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBAppBrandCustomer, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }


        public static string GetAppBrandCustomerIdListByCompany(string companyId)
        {
            List<EnAppBrandCustomer> list = GetAppBrandCustomerList(" companyid=" + companyId);
            StringBuilder sb = new StringBuilder();
            foreach (EnAppBrandCustomer b in list)
            {
                sb.Append(b.id + ",");
            }

            return sb.ToString().Length > 0 && sb.ToString().EndsWith(",") ? sb.ToString().Substring(0, sb.ToString().Length - 1) : sb.ToString();

        }


        ///删除对象
        public static int UpAppBrandCustomer(int id)
        {
            return DataCommon.UpdateValue(TableName.TBAppBrandCustomer, "auditstatus", "1", " where id=" + id);
        }

        ///删除对象
        public static int DeleteAppBrandCustomer(int id)
        {
            return DeleteAppBrandCustomer(" where id=" + id);
        }
        ///删除对象
        public static int DeleteAppBrandCustomerByIdList(string idList)
        {
            return DeleteAppBrandCustomer(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteAppBrandCustomer(string strWhere)
        {
            return DataCommon.Delete(TableName.TBAppBrandCustomer, strWhere);
        }
        #endregion


        ///删除对象
        public static int DeleteAppProductCustomer(int id)
        {
            return DeleteAppBrandCustomer(" where id=" + id);
        }
        ///删除对象
        public static int DeleteAppProductCustomerByIdList(string idList)
        {
            return DeleteAppProductCustomer(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteAppProductCustomer(string strWhere)
        {
            return DataCommon.Delete(TableName.TBAppBrandProduct, strWhere);
        }

    }
}

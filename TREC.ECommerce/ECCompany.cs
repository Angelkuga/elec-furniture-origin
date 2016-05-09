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
    public class ECCompany
    {
        public static int ExitComapnyTitle(string title)
        {
            return Companys.ExitComapny(title);
        }

        public static EnWebCompany GetWebCompanyInfo(string strWhere)
        {
            return Companys.GetWebCompanyInfo(strWhere);
        }
        public static DataTable GetPromotionsInfor(int companyId)
        {
            return Companys.GetPromotionsInfor(companyId);
        }
        public static List<EnWebCompany> GetWebCompanyList(int PageIndex, int PageSize, string strWhere, string sortkey, string ordertype, out int pageCount)
        {
            return Companys.GetWebCompanyList(PageIndex, PageSize, strWhere, sortkey, ordertype, out  pageCount);
        }

        public static List<EnWebCompanyBrand> GetWebCompanyBrandList(int PageIndex, int PageSize, string strWhere, string sortkey, string ordertype, out int pageCount)
        {
            return Companys.GetWebCompanyBrandList(PageIndex, PageSize, strWhere, sortkey, ordertype, out  pageCount);
        }

        public static List<EnSearchItem> GetSearchItem()
        {
            List<EnSearchItem> list = new List<EnSearchItem>();
            List<EnSearchItem> itemList = (List<EnSearchItem>)DataCache.GetCache(CacheKey.CompanySearchItemList);

            if (itemList == null)
            {
                itemList = Companys.GetCompanySearchItem();
                DataCache.SetCache(CacheKey.CompanySearchItemList, itemList);
            }


            foreach (EnSearchItem item in itemList)
            {
                if (item.type == "brand" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchBrand != "" && ECommon.QuerySearchBrand.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                if (item.type == "style" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchStyle != "" && ECommon.QuerySearchStyle.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                if (item.type == "material" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchMaterial != "" && ECommon.QuerySearchMaterial.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                if (item.type == "spread" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchSpread != "" && ECommon.QuerySearchSpread.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                if (item.type == "staffsize" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchStaffsize != "" && ECommon.QuerySearchStaffsize.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                list.Add(item);
            }
            return list;
        }

        public static int UpConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBCompany, "descript", con, " where id=" + id);
        }

        #region  Method-Company
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditCompany(EnCompany model)
        {
            return Companys.EditCompany(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnCompany GetCompanyInfo(string strWhere)
        {
            return Companys.GetCompanyInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnCompany> GetCompanyList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Companys.GetCompanyList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnCompany> GetCompanyList(string strWhere, out int pageCount)
        {
            return GetCompanyList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnCompany> GetCompanyList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetCompanyList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetCompanyListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBCompany, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteCompany(int id)
        {
            return DeleteCompany(" where id=" + id);
        }
        ///删除对象
        public static int DeleteCompanyByIdList(string idList)
        {
            return DeleteCompany(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteCompany(string strWhere)
        {
            return DataCommon.Delete(TableName.TBCompany, strWhere);
        }

        /// <summary>
        /// 更新上/下线对象/审核通过不过
        /// rafer
        /// 5-17
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ModifyCompanyByID(string values, string files, string where)
        {
            return DataCommon.UpdateValue(TableName.TBCompany, files, values, where);
        }

        /// <summary>
        /// 通用的上下线
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="values"></param>
        /// <param name="files"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int ModifyTable(string tablename, string values, string files, string where)
        {
            return DataCommon.UpdateValue(tablename, files, values, where);
        }

        #endregion

        #region  Method-CompanyGroup
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditCompanyGroup(EnCompanyGroup model)
        {
            return Companys.EditCompanyGroup(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnCompanyGroup GetCompanyGroupInfo(string strWhere)
        {
            return Companys.GetCompanyGroupInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnCompanyGroup> GetCompanyGroupList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Companys.GetCompanyGroupList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnCompanyGroup> GetCompanyGroupList(string strWhere, out int pageCount)
        {
            return GetCompanyGroupList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnCompanyGroup> GetCompanyGroupList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetCompanyGroupList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetCompanyGroupListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBCompanyGroup, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnCompanyGroup(int id)
        {
            return DeletEnCompanyGroup(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnCompanyGroupByIdList(string idList)
        {
            return DeletEnCompanyGroup(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnCompanyGroup(string strWhere)
        {
            return DataCommon.Delete(TableName.TBCompanyGroup, strWhere);
        }
        #endregion


        #region 后台列表查询
        /// <summary>
        /// 后台Company列表查询
        /// </summary>
        public static List<EnCompany> GetAdminCompanyList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Companys.GetAdminCompanyList(PageIndex, PageSize, strWhere, out pageCount);
        }
        #endregion
    }
}

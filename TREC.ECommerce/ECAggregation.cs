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
    public class ECAggregation
    {
        public static List<EnWebAggregation> GetWebAggregationList(int PageIndex, int PageSize, string strWhere,string sortKey, string orderby, out int pageCount)
        {
            return Aggregations.GetWebAggregationList(PageIndex, PageSize, strWhere,sortKey, orderby, out pageCount);
        }
        public static List<EnWebAggregation> GetWebAggregationList(string strWhere,string sortkey,string ordertype)
        {
            int pageCount = 0;
            return GetWebAggregationList(1, 50, strWhere, sortkey, ordertype, out pageCount);
        }
        public static List<EnWebAggregation> GetWebAggregationList(string strWhere)
        {
            int pageCount = 0;
            return GetWebAggregationList(1, 50, strWhere, "", "", out pageCount);
        }
        public static List<EnWebAggregation> GetWebAggregationListByParentIdList(string parentidlist)
        {
            int pageCount = 0;
            return GetWebAggregationList(1, 50, " and parent in (" + parentidlist + ")", "","", out pageCount);
        }

        public static List<EnWebAggregation> GetWebIndexAggregationListByParentIdList()
        {
            List<EnWebAggregation> list = null;
            int pageCount = 0;
            list = GetWebAggregationList(1, 100000, " and parent in (1,6,9,14,17)", "sort","desc", out pageCount);
            //if (DataCache.GetCache(CacheKey.IndexAggregation) != null)
            //{
            //    list = (List<EnWebAggregation>)DataCache.GetCache(CacheKey.IndexAggregation);
            //}
            //else
            //{
            //   int pageCount = 0;
            //   list= GetWebAggregationList(1, 50, " parent in (1,6,9,14,17)", "", out pageCount);
            //}
            return list;
        }

        public static List<EnWebAggregation> GetWebCommonAggregationListByParentIdList()
        {
            List<EnWebAggregation> list = null;
            int pageCount = 0;
            list = GetWebAggregationList(1, 50, " and parent in (27,28,29,33,34,37)", "", "", out pageCount);
            //if (DataCache.GetCache(CacheKey.CommonAggregation) != null)
            //{
            //    list = (List<EnWebAggregation>)DataCache.GetCache(CacheKey.CommonAggregation);
            //}
            //else
            //{
            //   int pageCount = 0;
            //   list= GetWebAggregationList(1, 50, " parent in (1,6,9,14,17)", "", out pageCount);
            //}
            return list;
        }

        #region  Method-Aggregation
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAggregation(EnAggregation model)
        {
            return Aggregations.EditAggregation(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnAggregation GetAggregationInfo(string strWhere)
        {
            return Aggregations.GetAggregationInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnAggregation> GetAggregationList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Aggregations.GetAggregationList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAggregation> GetAggregationList(string strWhere, out int pageCount)
        {
            return GetAggregationList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAggregation> GetAggregationList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetAggregationList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetAggregationListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBAggregation, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteAggregation(int id)
        {
            return DeleteAggregation(" where id=" + id);
        }
        ///删除对象
        public static int DeleteAggregationByIdList(string idList)
        {
            return DeleteAggregation(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteAggregation(string strWhere)
        {
            return DataCommon.Delete(TableName.TBAggregation, strWhere);
        }
        #endregion

        #region  Method-AggregationType
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAggregationType(EnAggregationType model)
        {
            return Aggregations.EditAggregationType(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnAggregationType GetAggregationTypeInfo(string strWhere)
        {
            return Aggregations.GetAggregationTypeInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnAggregationType> GetAggregationTypeList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnAggregationType> list=Aggregations.GetAggregationTypeList(PageIndex, PageSize, strWhere, out pageCount);
            List<EnAggregationType> templist=new List<EnAggregationType>();
            foreach (EnAggregationType t in list.Where(s => s.parentid == 0))
            {
                templist.Add(t);
                foreach (EnAggregationType s in list.Where(s=>s.parentid==t.id))
                {
                    templist.Add(s);
                }
            }
            return templist;
        }

        ///获取数据列表
        public static List<EnAggregationType> GetAggregationTypeList(string strWhere, out int pageCount)
        {
            return GetAggregationTypeList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAggregationType> GetAggregationTypeList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetAggregationTypeList(-1, 0, strWhere, out tmpPageCount);
        }

        ///获取数据列表
        public static List<EnAggregationType> GetAggregationTypeListToDDL()
        {
            int tmpPageCount = 0;
            List < EnAggregationType > list = GetAggregationTypeList(-1, 0, "", out tmpPageCount);
            foreach (EnAggregationType t in list)
            {
                if (t.parentid != 0)
                {
                    t.title = "|--" + t.title;
                }
            }
            return list;
        }

        //获取数据列表ToDataTable
        public static DataTable GetAggregationTypeListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBAggregationType, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteAggregationType(int id)
        {
            return DeleteAggregationType(" where id=" + id);
        }
        ///删除对象
        public static int DeleteAggregationTypeByIdList(string idList)
        {
            return DeleteAggregationType(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteAggregationType(string strWhere)
        {
            return DataCommon.Delete(TableName.TBAggregationType, strWhere);
        }
        #endregion
    }
}

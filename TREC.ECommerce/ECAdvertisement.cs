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
    public class ECAdvertisement
    {
        #region  Method-Advertisement
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditAdvertisement(EnAdvertisement model)
        {
            return Advertisements.EditAdvertisement(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnAdvertisement GetAdvertisementInfo(string strWhere)
        {
            return Advertisements.GetAdvertisementInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnAdvertisement> GetAdvertisementList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Advertisements.GetAdvertisementList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAdvertisement> GetAdvertisementList(string strWhere, out int pageCount)
        {
            return GetAdvertisementList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnAdvertisement> GetAdvertisementList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetAdvertisementList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetAdvertisementListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBAdvertisement, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnAdvertisement(int id)
        {
            return DeletEnAdvertisement(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnAdvertisementByIdList(string idList)
        {
            return DeletEnAdvertisement(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnAdvertisement(string strWhere)
        {
            return DataCommon.Delete(TableName.TBAdvertisement, strWhere);
        }

        #region 2015-01-29 shen

        public static List<t_advertising> AdvertisingList(string strWhere)
        {
            return Advertisements.AdvertisingList(strWhere);
        }
        /// <summary>
        /// 导航推荐品牌
        /// </summary>
        /// <returns></returns>
        public static List<t_navigationbrand> t_navigationbrandList() {
            return Advertisements.t_navigationbrandList();
        }
        /// <summary>
        /// 获取商家活动信息
        /// shen 2015-02-04
        /// </summary>
        /// <param name="pageindex">当前页数</param>
        /// <param name="pagecount">总页数</param>
        /// <param name="pagesize">每页显示数量</param>
        /// <param name="marketid">商场id</param>
        /// <param name="brandid">品牌id</param>
        /// <param name="areaid">区域id</param>
        /// <param name="keyword">搜索关键词</param>
        /// <param name="type">活动发起方 (卖场,工厂,店铺)</param>
        /// <param name="sorttype">排序方式(asc desc)</param>
        /// <param name="sort">排序类型</param>
        public static DataTable HDSearch(int pageindex, int pagecount, int pagesize, int marketid, int brandid, string areaid,
            string keyword,   int type, string sorttype, string sort)
        {
            return Advertisements.HDSearch(  pageindex,   pagecount,   pagesize,    marketid,   brandid,   areaid,
              keyword,   type,   sorttype,   sort);
        }
        public static DataSet HDSearch(int pageindex, int pagesize, string condiction, string order)
        {
            return Advertisements.HDSearch(pageindex, pagesize, condiction, order);
        }
        /// <summary>
        /// 首页淘宝贝详情
        /// </summary>
        /// <param name="did">大类id</param>
        /// <param name="xid">小类id</param>
        /// <returns></returns>
        public static DataSet TBBSearch(int did,int xid) {
            return Advertisements.TBBSearch(did,xid);
        }

        #endregion

        #endregion
    }
}

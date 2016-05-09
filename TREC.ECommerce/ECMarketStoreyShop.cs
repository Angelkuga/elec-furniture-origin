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
    public class ECMarketStoreyShop
    {
        public static EnWebMarketStoreyShop GetWebMarketStoreyShopInfo(string strWhere)
        {
            return MarketStoreyShops.GetWebMarketStoreyShopInfo(strWhere);
        }

        public static List<EnWebMarketStoreyShop> GetWebMarketStoreyShopList(int PageIndex, int PageSize, string strWhere,string sortkey, string ordertype, out int pageCount)
        {
            return MarketStoreyShops.GetWebWebMarketStoreyShopList(PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);

        }

        #region  Method-MarketStoreyShop


        public static int UpMarketShopLev(string id, string lev)
        {
            return DataCommon.UpdateValue(TableName.TBMarketStoreyShop, "lev", lev, " where id=" + id);
        }

        public static int UpMarketShopTop(string id, string value)
        {
            return DataCommon.UpdateValue(TableName.TBMarketStoreyShop, "istop", value, " where id=" + id);
        }

        public static int UpMarketShopRecommend(string id, string value)
        {
            return DataCommon.UpdateValue(TableName.TBMarketStoreyShop, "isrecommend", value, " where id=" + id);
        }


        public static int UpMarketShorey(List<EnMarketStoreyShop> list)
        {
            return MarketStoreyShops.UpMarketShorey(list);
        }

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMarketStoreyShop(EnMarketStoreyShop model)
        {
            return MarketStoreyShops.EditMarketStoreyShop(model);
        }

        #region 获取楼层店铺详细信息

        /// <summary>
        /// 获取楼层店铺详细信息
        /// </summary>
        /// <param name="strWhere"> where 条件 where id=1 and uid='</param>
        /// <returns></returns>
        public static EnMarketStoreyShop GetMarketStoreyShopInfo(string strWhere)
        {
            return MarketStoreyShops.GetMarketStoreyShopInfo(strWhere);
        }
        #endregion
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMarketStoreyShop> GetMarketStoreyShopList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return MarketStoreyShops.GetMarketStoreyShopList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMarketStoreyShop> GetMarketStoreyShopList(string strWhere, out int pageCount)
        {
            return GetMarketStoreyShopList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMarketStoreyShop> GetMarketStoreyShopList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetMarketStoreyShopList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetMarketStoreyShopListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBMarketStoreyShop, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteMarketStoreyShop(int id)
        {
            return DeleteMarketStoreyShop(" where id=" + id);
        }
        ///删除对象
        public static int DeleteMarketStoreyShopByIdList(string idList)
        {
            return DeleteMarketStoreyShop(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteMarketStoreyShopByShopIdList(string shopidList)
        {
            return DeleteMarketStoreyShop(" where shopid in (" + shopidList + ")");
        }
        ///删除对象
        public static int DeleteMarketStoreyShop(string strWhere)
        {
            return DataCommon.Delete(TableName.TBMarketStoreyShop, strWhere);
        }
        #endregion
    }
}

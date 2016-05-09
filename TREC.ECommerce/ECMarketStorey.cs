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
    public class ECMarketStorey
    {

        #region  Method-MarketStorey
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMarketStorey(EnMarketStorey model)
        {
            return MarketStoreys.EditMarketStorey(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMarketStorey GetMarketStoreyInfo(string strWhere)
        {
            return MarketStoreys.GetMarketStoreyInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMarketStorey> GetMarketStoreyList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return MarketStoreys.GetMarketStoreyList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMarketStorey> GetMarketStoreyList(string strWhere, out int pageCount)
        {
            return GetMarketStoreyList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMarketStorey> GetMarketStoreyList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetMarketStoreyList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetMarketStoreyListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBMarketStorey, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteMarketStorey(int id)
        {
            return DeleteMarketStorey(" where id=" + id);
        }
        ///删除对象
        public static int DeleteMarketStoreyByIdList(string idList)
        {
            return DeleteMarketStorey(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteMarketStorey(string strWhere)
        {
            return DataCommon.Delete(TableName.TBMarketStorey, strWhere);
        }
        #endregion
    }
}

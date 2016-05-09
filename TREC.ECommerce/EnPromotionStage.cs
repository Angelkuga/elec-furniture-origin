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
    public class ECPromotionStage
    {
        #region  Method-PromotionStage
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditPromotionStage(EnPromotionStage model)
        {
            return Promotions.EditPromotionStage(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnPromotionStage GetPromotionStageInfo(string strWhere)
        {
            return Promotions.GetPromotionStageInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnPromotionStage> GetPromotionStageList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Promotions.GetPromotionStageList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnPromotionStage> GetPromotionStageList(string strWhere, out int pageCount)
        {
            return GetPromotionStageList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnPromotionStage> GetPromotionStageList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetPromotionStageList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetPromotionStageListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBPromotionStage, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletePromotionStage(int id)
        {
            return DeletePromotionStage(" where id=" + id);
        }
        ///删除对象
        public static int DeletePromotionStageByIdList(string idList)
        {
            return DeletePromotionStage(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletePromotionStage(string strWhere)
        {
            return DataCommon.Delete(TableName.TBPromotionStage, strWhere);
        }
        #endregion
    }
}

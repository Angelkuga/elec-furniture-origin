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
    public class ECPromotionDef
    {

        public static List<EnWebPromotionInfoList> GetWebPromotionInfoList(int PageIndex, int PageSize, string strWhere, string sortkey, string orderby, out int pageCount)
        {
            return Promotions.GetWebPromotionInfoList(PageIndex, PageSize, strWhere, sortkey, orderby, out pageCount);
        }
        public static EnWebPromotionInfoList GetWebPromotionInfoListInfo(string strWhere)
        {
            return Promotions.GetWebPromotionInfoListInfo(strWhere);
        }
        public static int ExtWebPromotionDefByBrand(int bid,int pid)
        {
            return DataCommon.Exists(TableName.TBPromotionDef, " where value=" + bid + " and type=" + (int)EnumPromotionDefType.品牌 + " and pid=" + pid);
        }
        public static EnWebPromotionInfoList GetWebPromotionInfoListInfo(int pid,int id)
        {
            return Promotions.GetWebPromotionInfoListInfo(" where pid=" + pid + " and id=" + id);
        }

        public static int UpConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBPromotionDef, "descript", con, " where id=" + id);
        }

        public static int ExistsDef(EnPromotionDef model)
        {
            return DataCommon.Exists(TableName.TBPromotionDef, " where type='" + model.type + "' and value='" + model.value + "' and pid='" + model.pid + "'");
        }

        #region  Method-PromotionDef
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditPromotionDef(EnPromotionDef model)
        {
            return Promotions.EditPromotionDef(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnPromotionDef GetPromotionDefInfo(string strWhere)
        {
            return Promotions.GetPromotionDefInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnPromotionDef> GetPromotionDefList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Promotions.GetPromotionDefList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnPromotionDef> GetPromotionDefList(string strWhere, out int pageCount)
        {
            return GetPromotionDefList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnPromotionDef> GetPromotionDefList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetPromotionDefList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetPromotionDefListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBPromotionDef, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletePromotionDef(int id)
        {
            return DeletePromotionDef(" where id=" + id);
        }
        ///删除对象
        public static int DeletePromotionDefByIdList(string idList)
        {
            return DeletePromotionDef(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletePromotionDef(string strWhere)
        {
            return DataCommon.Delete(TableName.TBPromotionDef, strWhere);
        }
        #endregion
    }
}

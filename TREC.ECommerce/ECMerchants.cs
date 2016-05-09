using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TREC.Data;

namespace TREC.ECommerce
{
    public class ECMerchants
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMerchants(EnMerchants model)
        {
            return Merchants.EditMerchants(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMerchants GetMerchantsInfo(string strWhere)
        {
            return Merchants.GetMerchantsInfo(strWhere);
        }

        /// <summary>
        /// 获得分页的数据列表
        /// </summary>
        public static List<EnMerchants> GetMerchantsList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Merchants.GetMerchantsList(PageIndex, PageSize, strWhere, out pageCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMerchants> GetMerchantsList(string filed, string strWhere, string sort)
        {

            return Merchants.GetMerchantsList(filed, strWhere, sort);
        }

        ///删除对象
        public static int DeletMerchantsByIdList(string idList)
        {
            return DeleteMerchants(" where id in (" + idList + ")");
        }

        ///删除对象
        public static int DeleteMerchants(string strWhere)
        {
            return DataCommon.Delete(TableName.TBMerchants, strWhere);
        }

        public static List<EnWebMerchants> GetWebMerchantsList(int PageIndex, int PageSize, string strWhere, string sortkey, string ordertype, out int pageCount)
        {
            return Merchants.GetWebMerchantsList(PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);
        }


        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMerchantsCount(EnMerchants model)
        {
            return Merchants.EditMerchantsCount(model);
        }
        #endregion
    }
}

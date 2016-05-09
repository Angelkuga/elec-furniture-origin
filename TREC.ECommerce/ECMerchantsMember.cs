using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Data;
using TREC.Entity;

namespace TREC.ECommerce
{
    public class ECMerchantsMember
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMerchants(EnMerchantsMember model)
        {
            return MerchantsMember.EditMerchantsMember(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMerchantsMember GetMerchantsInfo(string strWhere)
        {
            return MerchantsMember.GetMerchantsMemberInfo(strWhere);
        }

        /// <summary>
        /// 获得分页的数据列表
        /// </summary>
        public static List<EnMerchantsMember> GetMerchantsList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return MerchantsMember.GetMerchantsMemberList(PageIndex, PageSize, strWhere, out pageCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMerchantsMember> GetMerchantsList(string filed, string strWhere, string sort)
        {

            return MerchantsMember.GetMerchantsMemberList(filed, strWhere, sort);
        }

        ///删除对象
        public static int DeletMerchantsMemberByIdList(string idList)
        {
            return DeleteMerchantsMember(" where id in (" + idList + ")");
        }

        ///删除对象
        public static int DeletMerchantsMemberByMerchantIdList(string idList)
        {
            return DeleteMerchantsMember(" where MerchantId in (" + idList + ")");
        }

        ///删除对象
        public static int DeleteMerchantsMember(string strWhere)
        {
            return DataCommon.Delete(TableName.TBMerchantsMember, strWhere);
        }
        #endregion
    }
}

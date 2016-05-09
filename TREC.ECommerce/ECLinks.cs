using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TREC.Data;

namespace TREC.ECommerce
{
    public class ECLinks
    {
        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditLinks(EnLinks model)
        {
            return Links.EditLinks(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnLinks GetMLinksInfo(string strWhere)
        {
            return Links.GetLinksInfo(strWhere);
        }

        /// <summary>
        /// 获得分页的数据列表
        /// </summary>
        public static List<EnLinks> GetLinksList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Links.GetLinksList(PageIndex, PageSize, strWhere, out pageCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnLinks> GetLinksList(string filed, string strWhere, string sort)
        {
            return Links.GetLinksList(filed, strWhere, sort);
        }

        ///删除对象
        public static int DeletLinksByIdList(string idList)
        {
            return DeleteLinks(" where id in (" + idList + ")");
        }

        ///删除对象
        public static int DeleteLinks(string strWhere)
        {
            return DataCommon.Delete(TableName.TBLink, strWhere);
        }

        #endregion
    }
}

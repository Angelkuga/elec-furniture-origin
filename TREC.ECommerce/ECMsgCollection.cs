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
    public class ECMsgCollection
    {
        /// <summary>
        /// Modify MsgCollection
        /// </summary>
        public static int ModifyMsgCollection(EnMsgCollection model)
        {
            return MsgCollection.ModifyMsgCollection(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMsgCollection GetMsgCollectionInfo(string strWhere)
        {
            return MsgCollection.GetMsgCollectionInfo(strWhere);
        }

        /// <summary>
        /// 清楚MsgCollection对应的对象
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int DeleteMsgCollection(string strWhere)
        {
            return MsgCollection.DeleteMsgCollection(strWhere);
        }

        /// <summary>
        /// 得到MsgCollection数据列表（分页）
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static List<EnMsgCollection> GetMsgCollectionList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return MsgCollection.GetMsgCollectionList(PageIndex, PageSize, strWhere, out pageCount);
        }


        /// <summary>
        /// 得到符合条件的报名数
        /// </summary>
        public static int GetMsgCollectionCount(string strWhere)
        {
            return MsgCollection.GetMsgCollectionCount(strWhere);
        }
    }
}

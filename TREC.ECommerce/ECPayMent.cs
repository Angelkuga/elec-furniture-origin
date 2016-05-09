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
    public class ECPayMent
    {
        /// <summary>
        /// Insert PayMent
        /// </summary>
        public static int InsertPayMent(EnPayMent model)
        {
            return PayMent.InsertPayMent(model);
        }

        /// <summary>
        /// Insert PayMentLog
        /// </summary>
        public static int InsertPayMentLog(EnPayMent model)
        {
            return PayMent.InsertPayMentLog(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnPayMent GetPayMent(string strWhere)
        {
            return PayMent.GetPayMent(strWhere);
        }

        /// <summary>
        /// 清楚PayMen对应的对象
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int DeletePayMent(string strWhere)
        {
            return PayMent.DeletePayMent(strWhere);
        }
    }
}

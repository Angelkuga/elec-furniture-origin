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
    public class ECSms
    {
        /// <summary>
        /// 更新SMS
        /// </summary>
        /// <param name="sms">sms对象</param>
        /// <returns></returns>
        public static int EditSms(EnSms sms)
        {
            return Sms.EditSms(sms);
        }
        
        public static int DeleteSms(int id)
        {
            return Sms.DeleteSms(id);
        }

        public static int DeleteSmsByList(string idlist)
        {
            return Sms.DeleteSmsByList(idlist);
        }

        /// <summary>
        /// 得到单个SMS对象
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static EnSms GetSmsInfo(string strWhere)
        {
            return Sms.GetSmsInfo(strWhere);
        }

        /// <summary>
        /// 得到SMS数据列表（分页）
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static List<EnSms> GetSmsList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Sms.GetSmsList(PageIndex, PageSize, strWhere, out pageCount);
        }

    }
}

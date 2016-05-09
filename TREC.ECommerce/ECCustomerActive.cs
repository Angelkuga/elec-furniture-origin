using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TREC.Data;

namespace TREC.ECommerce
{
    /// <summary>
    /// BLL用户激活类
    /// </summary>
    public class ECCustomerActive
    {
        /// <summary>
        /// 更新消费用户激活对像
        /// </summary>
        public static int EditCustomer(EnCustomerActive model)
        {
            return CustomerActive.EditCustomer(model);
        }
        /// <summary>
        /// 更具sql条件获取消费用户激活对象
        /// </summary>
        /// <param name="strWhere">where条件(要写where关键字)</param>
        /// <returns></returns>
        public static EnCustomerActive GetCustomerActive(string strWhere)
        {
            return CustomerActive.GetCustomerActive(strWhere);
        }

        /// <summary>
        /// 消费用户激活分页数据
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="strWhere">条件</param>
        /// <param name="pagecount">总页数</param>
        /// <returns></returns>
        public static List<EnCustomerActive> GetCustomerActiveList(int pageindex, int pagesize, string strWhere, out int pagecount)
        {
            return CustomerActive.GetCustomerActiveList(pageindex, pagesize, strWhere, out  pagecount);
        }

        /// <summary>
        /// 更具集团id获取卖场集团对象
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static EnCustomerActive GetCustomerActiveById(int Id)
        {
            return CustomerActive.GetCustomerActiveById(Id);
        }
    }
}

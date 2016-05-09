using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TREC.Data;
using System.Data.SqlClient;

namespace TREC.ECommerce
{
    /// <summary>
    /// BLL消费用户类
    /// </summary>
    public class ECCustomer
    {
        /// <summary>
        /// 更新消费用户对像
        /// </summary>
        public static int EditCustomer(EnCustomer model)
        {
            return Customer.EditCustomer(model);
        }
        /// <summary>
        /// 更具sql条件获取消费用户对象
        /// </summary>
        /// <param name="strWhere">where条件(要写where关键字)</param>
        /// <returns></returns>
        public static EnCustomer GetCustomer(string strWhere)
        {
            return Customer.GetCustomer(strWhere);
        }

        /// <summary>
        /// 消费用户登录
        /// </summary>
        /// <param name="uname">用户名 手机或mail</param>
        /// <param name="upwd">密码md5加密后</param>
        /// <param name="utype">账号类型 1 手机 2 mail</param>
        /// <returns></returns>
        public static EnCustomer LoginCustomer(string uname, string upwd, int utype = 1)
        {
            return Customer.LoginCustomer(uname, upwd, utype);
        }
        /// <summary>
        /// 消费用户分页数据
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="strWhere">条件</param>
        /// <param name="pagecount">总页数</param>
        /// <returns></returns>
        public static List<EnCustomer> GetCustomerList(int pageindex, int pagesize, string strWhere, out int pagecount)
        {
            return Customer.GetCustomerList(pageindex, pagesize, strWhere, out  pagecount);
        }
        /// <summary>
        /// 更具集团id获取卖场集团对象
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static EnCustomer GetCustomerById(int customerId)
        {
            return Customer.GetCustomerById(customerId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    /// <summary>
    /// 消费用户类
    /// </summary>
    public class EnCustomer
    {
        public int Id
        {
            set;
            get;
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UName { set; get; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UPassword { set; get; }
        /// <summary>
        /// 用户账号类型 1 手机 2 邮件
        /// </summary>
        public int UNameType { set; get; }
        /// <summary>
        /// 用户状态 0 未激活 1 激活
        /// </summary>
        public int UStatus { set; get; }
        /// <summary>
        /// 用户注册时间
        /// </summary>
        public DateTime? Regtime { set; get; }
        /// <summary>
        /// 用户注册IP
        /// </summary>
        public string RegIP { set; get; }
    }
}

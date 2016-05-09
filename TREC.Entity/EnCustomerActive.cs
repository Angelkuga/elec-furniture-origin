using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    /// <summary>
    /// 用户激活账号类
    /// </summary>
    public class EnCustomerActive
    {
        public int Id { set; get; }
        /// <summary>
        /// 验证激活号 邮件或手机
        /// </summary>
        public string AText { set; get; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string ACode { set; get; }
        /// <summary>
        /// 验证类型 1 手机注册 2 邮件注册 3 手机找密码 4 邮件找密码
        /// </summary>
        public int AType { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { set; get; }
        /// <summary>
        /// 验证数据状态 1 有效 0 无效
        /// </summary>
        public int AStatus { set; get; }
    }
}

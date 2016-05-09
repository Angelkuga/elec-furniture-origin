using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{

    /// <summary>
    ///  用户活动报名
    /// </summary>
    public class EnMsgCollection
    {
        private int _id = 0;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name = string.Empty;
        /// <summary>
        /// 称呼
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _contact = string.Empty;
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
        private string _code = string.Empty;
        /// <summary>
        /// 手机验证码
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        private DateTime _createTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createTime = value; }
            get { return _createTime; }
        }
        
        /// <summary>
        /// 用户配送地址
        /// </summary>
        public string UserAddress
        {
            set;
            get;
        }
        /// <summary>
        /// 报名产品名称
        /// </summary>
        public string MsgInfo
        {
            set;
            get;
        }
        /// <summary>
        /// 报名产品ID
        /// </summary>
        public int ProdID
        {
            set;
            get;
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int MID
        {
            set;
            get;
        }
        /// <summary>
        /// 产品类 1 单品抢购 2 套组合 3 单品团购 4 
        /// </summary>
        public int ProdCon
        {
            set;
            get;
        }
        public int BrandId { get; set; }

        public string BrandName { get; set; }
    }
}

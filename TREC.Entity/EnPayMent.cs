using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    public class EnPayMent
    {
        private string _ordercode = string.Empty;
        private decimal _price = 0;
        private int _mid = 0;
        private int _types = 0;
        private string _bank = string.Empty;
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
        /// 支付银行
        /// </summary>
        public string Bank
        {
            set { _bank = value; }
            get { return _bank; }
        }
        /// <summary>
        /// 支付类型
        /// </summary>
        public int Types
        {
            set { _types = value; }
            get { return _types; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Mid
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode
        {
            set { _ordercode = value; }
            get { return _ordercode; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    [Serializable]
    public partial class EnSms
    {
        public EnSms()
        { }

        #region Model
        private int id;
        /// <summary>
        /// SMS表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string sms_phone;
        /// <summary>
        /// 发送号码
        /// </summary>
        public string Sms_phone
        {
            get { return sms_phone; }
            set { sms_phone = value; }
        }

        private string sms_content;
        /// <summary>
        /// 发送内动
        /// </summary>
        public string Sms_content
        {
            get { return sms_content; }
            set { sms_content = value; }
        }

        private int sms_number_quantity;
        /// <summary>
        /// 短信拆分条数
        /// </summary>
        public int Sms_number_quantity
        {
            get { return sms_number_quantity; }
            set { sms_number_quantity = value; }
        }

        private bool sms_status;
        /// <summary>
        /// 发送状态
        /// </summary>
        public bool Sms_status
        {
            get { return sms_status; }
            set { sms_status = value; }
        }

        private DateTime sms_send_time;
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime Sms_send_time
        {
            get { return sms_send_time; }
            set { sms_send_time = value; }
        }

        private string sms_return_string;
        /// <summary>
        /// 返回的字符串
        /// </summary>
        public string Sms_return_string
        {
            get { return sms_return_string; }
            set { sms_return_string = value; }
        }

        private int sms_return_number;
        /// <summary>
        /// 返回的数字
        /// </summary>
        public int Sms_return_number
        {
            get { return sms_return_number; }
            set { sms_return_number = value; }
        }

        private long sms_msgid;
        /// <summary>
        /// msgid
        /// </summary>
        public long Sms_msgid
        {
            get { return sms_msgid; }
            set { sms_msgid = value; }
        }

        private decimal sms_balance_money;
        /// <summary>
        /// 返回的字符串
        /// </summary>
        public decimal Sms_balance_money
        {
            get { return sms_balance_money; }
            set { sms_balance_money = value; }
        }

        #endregion
    }
}

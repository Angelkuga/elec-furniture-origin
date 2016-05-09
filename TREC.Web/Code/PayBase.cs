using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TREC.Web.Code
{
    /// <summary>
    /// 支付基类
    /// </summary>
    public class PayBase : System.Web.UI.Page
    {
        /// <summary>
        /// 支付类型
        /// </summary>
        public Dictionary<string, string> PayType
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("0", "未支付");
                _dic.Add("1", "全款支付");
                _dic.Add("2", "定金支付");
                _dic.Add("3", "余款支付");

                return _dic;
            }
        }

        /// <summary>
        /// 结果处理
        /// </summary>
        public Dictionary<string, string> Result
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("0", "未支付");
                _dic.Add("1", "定金支付完成");
                _dic.Add("2", "全款支付完成");
                _dic.Add("3", "余款支付完成");

                return _dic;
            }
        }

        public Dictionary<string, string> Deliverystatus
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("1", "备货中");
                _dic.Add("2", "送货中");
                _dic.Add("3", "已完成");
                return _dic;
            }
        }
        /// <summary>
        /// 配送方式
        /// </summary>
        public Dictionary<string, string> TransportMeth
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("1", "只工作日送货(双休日假日不送货)");
                _dic.Add("2", "工作日,双休日与节假日均可送货");
                _dic.Add("3", "只双休日节假日送货(工作日不送货)");
                return _dic;
            }
        }

    }
}